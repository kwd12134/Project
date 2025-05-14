using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MCMQ
{
    public class XmlHelper
    {
        #region 1.Xml序列化反序列化相关的方法
        public class CustomXmlWriter : XmlTextWriter
        {
            public CustomXmlWriter(Stream w, Encoding encoding) : base(w, encoding) { }
            public CustomXmlWriter(TextWriter w) : base(w) { }

            public override void WriteEndElement()
            {
                base.WriteEndElement();
                base.WriteRaw("\r\n");
            }

            public override void WriteFullEndElement()
            {
                base.WriteFullEndElement();
                base.WriteRaw("\r\n");
            }
        }
        /// <summary>
        /// 使用XmlSerializer序列化对象
        /// </summary>
        /// <typeparam name="T">需要序列化的对象类型，必须声明[Serializable]特征</typeparam>
        /// <param name="obj">需要序列化的对象</param>
        /// <param name="omitXmlDeclaration">true:省略XML声明;否则为false.默认false，即编写 XML 声明。</param>
        /// <returns>序列化后的字符串</returns>
        public static string EntityToXml<T>(T obj, bool omitXmlDeclaration = false) where T : class
        {
            /* This property only applies to XmlWriter instances that output text content to a stream; otherwise, this setting is ignored.
            可能很多朋友遇见过 不能转换成Xml不能反序列化成为UTF8XML声明的情况，就是这个原因。
            */
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.OmitXmlDeclaration = omitXmlDeclaration;
            xmlSettings.Encoding = new System.Text.UTF8Encoding(false);
            MemoryStream stream = new MemoryStream();
            XmlWriter xmlwriter = XmlWriter.Create(stream, xmlSettings); //这里如果直接写成：Encoding = Encoding.UTF8 会在生成的xml中加入BOM(Byte-order Mark) 信息(Unicode 字节顺序标记) ， 所以new System.Text.UTF8Encoding(false)是最佳方式，省得再做替换的麻烦
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty); //在XML序列化时去除默认命名空间xmlns:xsd和xmlns:xsi
            XmlSerializer ser = new XmlSerializer(typeof(T));
            ser.Serialize(xmlwriter, obj, xmlns);
            //去除空格
            var xmlString = Regex.Replace(Encoding.UTF8.GetString(stream.ToArray()), @"(?<=\?>)\s+|\s+(?=<)|\s+(?=</)", string.Empty);
            xmlString = Regex.Replace(xmlString, @"(</\w+>)", "$1\r\n");
            return xmlString;
        }


        /// <summary>
        /// 使用XmlSerializer序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">文件路径</param>
        /// <param name="obj">需要序列化的对象</param>
        /// <param name="omitXmlDeclaration">true:省略XML声明;否则为false.默认false，即编写 XML 声明。</param>
        /// <param name="removeDefaultNamespace">是否移除默认名称空间(如果对象定义时指定了:XmlRoot(Namespace = "http://www.xxx.com/xsd")则需要传false值进来)</param>
        /// <returns>序列化后的字符串</returns>
        public static void EntityToXmlFile<T>(string path, T obj, bool omitXmlDeclaration = false, bool removeDefaultNamespace = true)
        {
            XmlWriterSettings xmlSetings = new XmlWriterSettings();
            xmlSetings.OmitXmlDeclaration = omitXmlDeclaration;
            using (XmlWriter xmlwriter = XmlWriter.Create(path, xmlSetings))
            {
                XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
                if (removeDefaultNamespace)
                    xmlns.Add(String.Empty, String.Empty); //在XML序列化时去除默认命名空间xmlns:xsd和xmlns:xsi
                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(xmlwriter, obj, xmlns);
            }
        }

        private static byte[] ReadFile(string filePath)
        {
            byte[] bytes;
            //避免"正由另一进程使用,因此该进程无法访问此文件"造成异常 共享锁 flieShare必须为ReadWrite，但是如果文件不存在的话，还是会出现异常，所以这里不能吃掉任何异常，但是需要考虑到这些问题
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                bytes = new byte[fs.Length];
                int numBytesToRead = (int)fs.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    int n = fs.Read(bytes, numBytesRead, numBytesToRead);
                    if (n == 0)
                        break;
                    numBytesRead += n;
                    numBytesToRead -= n;
                }
            }
            return bytes;
        }


        /// <summary>
        /// 使用XmlSerializer反序列化对象
        /// </summary>
        /// <param name="xmlOfObject">需要反序列化的xml字符串</param>
        /// <returns>反序列化后的对象</returns>
        public static T XmlToEntity<T>(string xmlOfObject) where T : class
        {
            try
            {
                XmlReader xmlReader = XmlReader.Create(new StringReader(xmlOfObject), new XmlReaderSettings());
                return (T)new XmlSerializer(typeof(T)).Deserialize(xmlReader);
            }
            catch (Exception)
            {
                return null;
            }

        }


        /// <summary>
        /// 从文件读取并反序列化为对象 （解决: 多线程或多进程下读写并发问题）
        /// </summary>
        /// <typeparam name="T">返回的对象类型</typeparam>
        /// <param name="path">文件地址</param>
        /// <returns></returns>
        public static T XmlFileToEntity<T>(string path)
        {
            byte[] bytes = ReadFile(path);
            if (bytes.Length < 1)//当文件正在被写入数据时，可能读出为0
                for (int i = 0; i < 5; i++)
                {
                    //5次机会
                    bytes = ReadFile(path); // 采用这样诡异的做法避免独占文件和文件正在被写入时读出来的数据为0字节的问题。
                    if (bytes.Length > 0) break;
                    System.Threading.Thread.Sleep(50); //悲观情况下总共最多消耗1/4秒，读取文件
                }
            XmlDocument doc = new XmlDocument();
            doc.Load(new MemoryStream(bytes));
            if (doc.DocumentElement != null)
                return (T)new XmlSerializer(typeof(T)).Deserialize(new XmlNodeReader(doc.DocumentElement));
            return default(T);
        }


        #endregion

        #region 2.Xml文件读写操作的方法

        /// <summary>
        /// 创建XML文档
        /// </summary>
        /// <param name="name">根节点名称</param>
        /// <param name="type">根节点的一个属性值</param>
        /// <returns></returns>
        /// .net中调用方法：写入文件中,则：
        ///          document = XmlOperate.CreateXmlDocument("sex", "sexy");
        ///          document.Save("c:/bookstore.xml");        
        public static XmlDocument CreateXmlDocument(string name, string type)
        {
            XmlDocument doc = null;
            XmlElement rootEle = null;
            try
            {
                doc = new XmlDocument();
                doc.LoadXml("<" + name + "/>");
                rootEle = doc.DocumentElement;
                rootEle.SetAttribute("type", type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return doc;
        }


        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时返回该属性值，否则返回串联值</param>
        /// <returns>string</returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Read(path, "/Node", "")
         * XmlHelper.Read(path, "/Node/Element[@Attribute='Name']", "Attribute")
         ************************************************/
        public static string Read(string path, string node, string attribute)
        {
            string value = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                value = (attribute.Equals("") ? xn.InnerText : xn.Attributes[attribute].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return value;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="element">元素名，非空时插入新元素，否则在该元素中插入属性</param>
        /// <param name="attribute">属性名，非空时插入该元素属性值，否则插入元素值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Insert(path, "/Node", "Element", "", "Value")
         * XmlHelper.Insert(path, "/Node", "Element", "Attribute", "Value")
         * XmlHelper.Insert(path, "/Node", "", "Attribute", "Value")
         ************************************************/
        public static void Insert(string path, string node, string element, string attribute, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                if (element.Equals(""))
                {
                    if (!attribute.Equals(""))
                    {
                        XmlElement xe = (XmlElement)xn;
                        xe.SetAttribute(attribute, value);
                    }
                }
                else
                {
                    XmlElement xe = doc.CreateElement(element);
                    if (attribute.Equals(""))
                        xe.InnerText = value;
                    else
                        xe.SetAttribute(attribute, value);
                    xn.AppendChild(xe);
                }
                doc.Save(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Insert(path, "/Node", "", "Value")
         * XmlHelper.Insert(path, "/Node", "Attribute", "Value")
         ************************************************/
        public static void Update(string path, string node, string attribute, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                    xe.InnerText = value;
                else
                    xe.SetAttribute(attribute, value);
                doc.Save(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时删除该节点属性值，否则删除节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Delete(path, "/Node", "")
         * XmlHelper.Delete(path, "/Node", "Attribute")
         ************************************************/
        public static void Delete(string path, string node, string attribute)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                    xn.ParentNode.RemoveChild(xn);
                else
                    xe.RemoveAttribute(attribute);
                doc.Save(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
