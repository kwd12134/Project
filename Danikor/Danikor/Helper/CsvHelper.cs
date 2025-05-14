using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class CsvHelper
    {
        /// <summary>
        /// 将CSV文件中内容读取到DataTable中
        /// </summary>
        /// <param name="path">CSV文件路径</param>
        /// <param name="hasTitle">是否将CSV文件的第一行读取为DataTable的列名</param>
        /// <returns></returns>
        public static DataTable CsvToDataTable(string path, bool hasTitle = false)
        {
            DataTable dt = new DataTable();           //要输出的数据表
            StreamReader sr = new StreamReader(path, Encoding.Default); //文件读入流
            bool bFirst = true;                       //指示是否第一次读取数据

            //逐行读取
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] elements = line.Split(',');

                //第一次读取数据时，要创建数据列
                if (bFirst)
                {
                    for (int i = 0; i < elements.Length; i++)
                    {
                        dt.Columns.Add();
                    }
                    bFirst = false;
                }
                //有标题行时，第一行当做标题行处理
                if (hasTitle)
                {
                    for (int i = 0; i < dt.Columns.Count && i < elements.Length; i++)
                    {
                        dt.Columns[i].ColumnName = elements[i];
                    }
                    hasTitle = false;
                }
                else //读取一行数据
                {
                    if (elements.Length == dt.Columns.Count)
                    {
                        dt.Rows.Add(elements);
                    }
                    else
                    {
                        throw new Exception("CSV格式错误：表格各行列数不一致");
                    }
                }
            }
            sr.Close();
            return dt;
        }

        /// <summary>
        /// 将CSV文件中的内容读取转换成List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="hasTitle"></param>
        /// <returns></returns>
        public static List<T> CsvToList<T>(string path, bool hasTitle = false)
        {
            DataTable dataTable = CsvToDataTable(path, hasTitle);

            return DataTableToList<T>(dataTable);
        }


        /// <summary>
        /// 将DataTable内容保存到CSV文件中
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="path">CSV文件地址</param>
        /// <param name="hasTitle">是否要输出数据表各列列名作为CSV文件第一行</param>
        public static void DataTableToCsv(DataTable dt, string path, bool hasTitle = false)
        {
            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);

            //输出标题行（如果有）
            if (hasTitle)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sw.Write(dt.Columns[i].ColumnName);
                    if (i != dt.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.WriteLine();
            }

            //输出文件内容
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sw.Write(dt.Rows[i][j].ToString());
                    if (j != dt.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.WriteLine();
            }

            sw.Close();
        }

        /// <summary>
        /// 将List集合转换CSV文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="path"></param>
        /// <param name="hasTitle"></param>
        public static void ListToCsv<T>(List<T> list, string path, bool hasTitle = false)
        {
            DataTable dataTable = ListToDataTable<T>(list);

            DataTableToCsv(dataTable, path, hasTitle);
        }


        #region DataTableToList
        public static List<T> DataTableToList<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }
            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }

        private static List<T> ConvertTo<T>(IList<DataRow> rows)
        {
            List<T> list = null;
            if (rows != null)
            {

                list = new List<T>();
                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }

            }
            return list;
        }

        private static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);

            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);

                    try
                    {
                        object value = row[column.ColumnName];

                        SetObjectPropertyValue(obj, column.ColumnName, value.ToString());
                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return obj;
        }

        /// <summary>
        /// 通过属性名称设置值
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">对象</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        private static bool SetObjectPropertyValue<T>(T obj, string propertyName, string value)
        {
            try
            {
                Type type = typeof(T);

                object t = Convert.ChangeType(value, type.GetProperty(propertyName).PropertyType);

                type.GetProperty(propertyName).SetValue(obj, t, null);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region ListToDataTable

        public static DataTable ListToDataTable<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();

            var dt = new DataTable();

            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());

            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();

                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }

                    object[] array = tempList.ToArray();

                    dt.LoadDataRow(array, true);

                }
            }
            return dt;
        }

        #endregion

        #region 写入到CSV

        /// <summary>
        /// 写入到CSV
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="dataList">数据集合</param>
        /// <param name="title">标题集合</param>
        public static void WriteToCsv(string path, List<string> dataList, List<string> title = null, string remark = null)
        {
            StreamWriter streamWriter = null;

            try
            {
                //说明是第一次，因为第一次需要写入title
                if (!File.Exists(path))
                {
                    streamWriter = new StreamWriter(path, false, Encoding.Default);

                    if (remark != null)
                    {
                        //写入一些备注信息
                        streamWriter.WriteLine(remark, Encoding.Default);
                    }

                    if (title != null)
                    {
                        //写入标题
                        streamWriter.WriteLine(string.Join(",", title), Encoding.Default);
                    }
                }
                else
                {
                    //写入数据
                    streamWriter = new StreamWriter(path, true, Encoding.Default);
                }

                streamWriter.WriteLine(string.Join(",", dataList), Encoding.Default);

                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Csv写入失败：" + ex.Message);
            }
        }

        #endregion

    }
}
