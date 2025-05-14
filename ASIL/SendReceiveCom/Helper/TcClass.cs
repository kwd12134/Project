using System;
using System.IO;
using System.Xml;

namespace SendReceiveCom
{

    public class TcClass
    {

        public string pis2Ip { get; set; }


        public int pis2Port { get; set; }


        public string jinceIp { get; set; }


        public int jincePort { get; set; }


        public string comId { get; set; }


        public int baudRate { get; set; }


        public int dataBits { get; set; }


        public int stopBit { get; set; }


        public string parity { get; set; }


        public string SendQueue { get; set; }


        public string SendQueue_ictest { get; set; }


        public string ReplyQueue { get; set; }


        public string JinceConmond { get; set; }


        /// <summary>
        /// 解析
        /// </summary>
        public string JinceSN { get; set; }


        public bool ASIL1_check { get; set; }


        public bool ASIL2_check { get; set; }


        public bool ASIL3_check { get; set; }


        public bool ASIL4_check { get; set; }


        public bool ASIL5_check { get; set; }


        public bool ASIL6_check { get; set; }


        public bool ASIL7_check { get; set; }


        public bool ASIL8_check { get; set; }


        public bool frequency1_check { get; set; }


        public bool frequency2_check { get; set; }


        public double ASIL1_Min { get; set; }


        public double ASIL2_Min { get; set; }


        public double ASIL3_Min { get; set; }


        public double ASIL4_Min { get; set; }


        public double ASIL5_Min { get; set; }


        public double ASIL6_Min { get; set; }


        public double ASIL7_Min { get; set; }


        public double ASIL8_Min { get; set; }


        public double frequency1_Min { get; set; }


        public double frequency2_Min { get; set; }


        public double ASIL1_Max { get; set; }


        public double ASIL2_Max { get; set; }


        public double ASIL3_Max { get; set; }


        public double ASIL4_Max { get; set; }


        public double ASIL5_Max { get; set; }


        public double ASIL6_Max { get; set; }


        public double ASIL7_Max { get; set; }


        public double ASIL8_Max { get; set; }


        public double frequency1_Max { get; set; }


        public double frequency2_Max { get; set; }


        public string User_ID { get; set; }


        public string user_id { get; set; }


        public string Station_ID { get; set; }


        public string unique_id { get; set; }


        public string test_result { get; set; }


        public string measure_type { get; set; }


        public string fw_version { get; set; }


        public string part_no { get; set; }


        public string model_no { get; set; }


        public string Operator { get; set; }


        public string EQP_ID { get; set; }

        public string PanelPosition { get; set; }

        public bool PanelPositionState { get; set; }

        public string type1 { get; set; }


        public string type2 { get; set; }

        public string CurrentType { get; set; }


        public string unifomity { get; set; }


        public string max_lumi { get; set; }


        public bool PIS2_check { get; set; }


        public string random_number { get; set; }

        public string CurrentRecipeName { get; set; }

        public string DayShift { get; set; }

        public string NightShift { get; set; }

        public string ModelName { get; set; }

        public string SampleSN { get; set; }

        public string CCDTYPE1 { get; set; }
        public string CCDTYPE2 { get; set; }
        public string CCDTYPE3 { get; set; }
        public string CCDTYPE4 { get; set; }
        public string CCDTYPE5 { get; set; }
        public string CCDTYPE6 { get; set; }
        public string CCDTYPE7 { get; set; }
        public string CCDTYPE8 { get; set; }
        public string CCDTYPE9 { get; set; }
        public string CCDTYPE10 { get; set; }

        public void Display()
        {
            this.path = Directory.GetCurrentDirectory() + "\\PortController.xml";
            this.xmlDoc.Load(this.path);
            this.xn = this.xmlDoc.SelectSingleNode("AppConfig");
            this.xnlist = this.xn.ChildNodes;
            foreach (object obj in this.xnlist)
            {
                XmlNode xnf = (XmlNode)obj;
                XmlElement xe = (XmlElement)xnf;
                bool judge1 = xe.GetAttribute("name") == "CCDTYPE1";
                if (judge1)
                {
                    this.CCDTYPE1 = xe.GetAttribute("value");
                }
                bool judge2 = xe.GetAttribute("name") == "CCDTYPE2";
                if (judge2)
                {
                    this.CCDTYPE2 = xe.GetAttribute("value");
                }
                bool judge3 = xe.GetAttribute("name") == "CCDTYPE3";
                if (judge3)
                {
                    this.CCDTYPE3 = xe.GetAttribute("value");
                }
                bool judge4 = xe.GetAttribute("name") == "CCDTYPE4";
                if (judge4)
                {
                    this.CCDTYPE4 = xe.GetAttribute("value");
                }
                bool judge5 = xe.GetAttribute("name") == "CCDTYPE5";
                if (judge5)
                {
                    this.CCDTYPE5 = xe.GetAttribute("value");
                }
                bool judge6 = xe.GetAttribute("name") == "CCDTYPE6";
                if (judge6)
                {
                    this.CCDTYPE6 = xe.GetAttribute("value");
                }
                bool judge7 = xe.GetAttribute("name") == "CCDTYPE7";
                if (judge7)
                {
                    this.CCDTYPE7 = xe.GetAttribute("value");
                }
                bool judge8 = xe.GetAttribute("name") == "CCDTYPE8";
                if (judge8)
                {
                    this.CCDTYPE8 = xe.GetAttribute("value");
                }
                bool judge9 = xe.GetAttribute("name") == "CCDTYPE9";
                if (judge9)
                {
                    this.CCDTYPE9 = xe.GetAttribute("value");
                }
                bool judge10 = xe.GetAttribute("name") == "CCDTYPE10";
                if (judge10)
                {
                    this.CCDTYPE10 = xe.GetAttribute("value");
                }
                bool flag_1 = xe.GetAttribute("name") == "ModelName";
                if (flag_1)
                {
                    this.ModelName = xe.GetAttribute("value");
                }
                bool flag_2 = xe.GetAttribute("name") == "SampleSN";
                if (flag_2)
                {
                    this.SampleSN = xe.GetAttribute("value");
                }
                bool flag_3 = xe.GetAttribute("name") == "DayShift";
                if (flag_3)
                {
                    this.DayShift = xe.GetAttribute("value");
                }
                bool flag_4 = xe.GetAttribute("name") == "NightShift";
                if (flag_4)
                {
                    this.NightShift = xe.GetAttribute("value");
                }
                bool flag = xe.GetAttribute("name") == "COM_PortNum";
                if (flag)
                {
                    this.comId = xe.GetAttribute("value");
                }
                bool flag1 = xe.GetAttribute("name") == "CurrentRecipeName";
                if (flag1)
                {
                    this.CurrentRecipeName = xe.GetAttribute("value");
                }
                bool flag01 = xe.GetAttribute("name") == "DayShift";
                if (flag01)
                {
                    this.DayShift = xe.GetAttribute("value");
                }
                bool flag02 = xe.GetAttribute("name") == "NightShift";
                if (flag02)
                {
                    this.NightShift = xe.GetAttribute("value");
                }
                bool flag2 = xe.GetAttribute("name") == "COM_BaudRate";
                if (flag2)
                {
                    this.baudRate = Convert.ToInt32(xe.GetAttribute("value"));
                }
                bool flag3 = xe.GetAttribute("name") == "COM_DataBits";
                if (flag3)
                {
                    this.dataBits = Convert.ToInt32(xe.GetAttribute("value"));
                }
                bool flag4 = xe.GetAttribute("name") == "COM_StopBits";
                if (flag4)
                {
                    this.stopBit = Convert.ToInt32(xe.GetAttribute("value"));
                }
                bool flag5 = xe.GetAttribute("name") == "COM_Parity";
                if (flag5)
                {
                    this.parity = xe.GetAttribute("value");
                }
                bool flag6 = xe.GetAttribute("name") == "PIS2_IP";
                if (flag6)
                {
                    this.pis2Ip = xe.GetAttribute("value");
                }
                bool flag7 = xe.GetAttribute("name") == "PIS2_Port";
                if (flag7)
                {
                    this.pis2Port = Convert.ToInt32(xe.GetAttribute("value"));
                }
                bool flag8 = xe.GetAttribute("name") == "JINCE_IP";
                if (flag8)
                {
                    this.jinceIp = xe.GetAttribute("value");
                }
                bool flag9 = xe.GetAttribute("name") == "JINCE_Port";
                if (flag9)
                {
                    this.jincePort = Convert.ToInt32(xe.GetAttribute("value"));
                }
                bool flag10 = xe.GetAttribute("name") == "SendQueue";
                if (flag10)
                {
                    this.SendQueue = xe.GetAttribute("value");
                }
                bool flag11 = xe.GetAttribute("name") == "SendQueue_ictest";
                if (flag11)
                {
                    this.SendQueue_ictest = xe.GetAttribute("value");
                }
                bool flag12 = xe.GetAttribute("name") == "ReplyQueue";
                if (flag12)
                {
                    this.ReplyQueue = xe.GetAttribute("value") + this.random_number;
                }
                bool flag13 = xe.GetAttribute("name") == "ASIL1_check";
                if (flag13)
                {
                    this.ASIL1_check = Convert.ToBoolean(xe.GetAttribute("value"));
                }
                bool flag14 = xe.GetAttribute("name") == "ASIL1_Min";
                if (flag14)
                {
                    this.ASIL1_Min = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag15 = xe.GetAttribute("name") == "ASIL1_Max";
                if (flag15)
                {
                    this.ASIL1_Max = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag16 = xe.GetAttribute("name") == "ASIL2_check";
                if (flag16)
                {
                    this.ASIL2_check = Convert.ToBoolean(xe.GetAttribute("value"));
                }
                bool flag17 = xe.GetAttribute("name") == "ASIL2_Min";
                if (flag17)
                {
                    this.ASIL2_Min = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag18 = xe.GetAttribute("name") == "ASIL2_Max";
                if (flag18)
                {
                    this.ASIL2_Max = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag19 = xe.GetAttribute("name") == "ASIL3_check";
                if (flag19)
                {
                    this.ASIL3_check = Convert.ToBoolean(xe.GetAttribute("value"));
                }
                bool flag20 = xe.GetAttribute("name") == "ASIL3_Min";
                if (flag20)
                {
                    this.ASIL3_Min = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag21 = xe.GetAttribute("name") == "ASIL3_Max";
                if (flag21)
                {
                    this.ASIL3_Max = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag22 = xe.GetAttribute("name") == "ASIL4_check";
                if (flag22)
                {
                    this.ASIL4_check = Convert.ToBoolean(xe.GetAttribute("value"));
                }
                bool flag23 = xe.GetAttribute("name") == "ASIL4_Min";
                if (flag23)
                {
                    this.ASIL4_Min = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag24 = xe.GetAttribute("name") == "ASIL4_Max";
                if (flag24)
                {
                    this.ASIL4_Max = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag25 = xe.GetAttribute("name") == "ASIL5_check";
                if (flag25)
                {
                    this.ASIL5_check = Convert.ToBoolean(xe.GetAttribute("value"));
                }
                bool flag26 = xe.GetAttribute("name") == "ASIL5_Min";
                if (flag26)
                {
                    this.ASIL5_Min = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag27 = xe.GetAttribute("name") == "ASIL5_Max";
                if (flag27)
                {
                    this.ASIL5_Max = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag28 = xe.GetAttribute("name") == "ASIL6_check";
                if (flag28)
                {
                    this.ASIL6_check = Convert.ToBoolean(xe.GetAttribute("value"));
                }
                bool flag29 = xe.GetAttribute("name") == "ASIL6_Min";
                if (flag29)
                {
                    this.ASIL6_Min = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag30 = xe.GetAttribute("name") == "ASIL6_Max";
                if (flag30)
                {
                    this.ASIL6_Max = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag31 = xe.GetAttribute("name") == "ASIL7_check";
                if (flag31)
                {
                    this.ASIL7_check = Convert.ToBoolean(xe.GetAttribute("value"));
                }
                bool flag32 = xe.GetAttribute("name") == "ASIL7_Min";
                if (flag32)
                {
                    this.ASIL7_Min = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag33 = xe.GetAttribute("name") == "ASIL7_Max";
                if (flag33)
                {
                    this.ASIL7_Max = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag34 = xe.GetAttribute("name") == "ASIL8_check";
                if (flag34)
                {
                    this.ASIL8_check = Convert.ToBoolean(xe.GetAttribute("value"));
                }
                bool flag35 = xe.GetAttribute("name") == "ASIL8_Min";
                if (flag35)
                {
                    this.ASIL8_Min = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag36 = xe.GetAttribute("name") == "ASIL8_Max";
                if (flag36)
                {
                    this.ASIL8_Max = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag37 = xe.GetAttribute("name") == "frequency1_check";
                if (flag37)
                {
                    this.frequency1_check = Convert.ToBoolean(xe.GetAttribute("value"));
                }
                bool flag38 = xe.GetAttribute("name") == "frequency1_Min";
                if (flag38)
                {
                    this.frequency1_Min = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag39 = xe.GetAttribute("name") == "frequency1_Max";
                if (flag39)
                {
                    this.frequency1_Max = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag40 = xe.GetAttribute("name") == "frequency2_check";
                if (flag40)
                {
                    this.frequency2_check = Convert.ToBoolean(xe.GetAttribute("value"));
                }
                bool flag41 = xe.GetAttribute("name") == "frequency2_Min";
                if (flag41)
                {
                    this.frequency2_Min = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag42 = xe.GetAttribute("name") == "frequency2_Max";
                if (flag42)
                {
                    this.frequency2_Max = Convert.ToDouble(xe.GetAttribute("value"));
                }
                bool flag43 = xe.GetAttribute("name") == "User_ID";
                if (flag43)
                {
                    this.User_ID = xe.GetAttribute("value");
                }
                bool flag44 = xe.GetAttribute("name") == "Station_ID";
                if (flag44)
                {
                    this.Station_ID = xe.GetAttribute("value");
                }
                bool flag45 = xe.GetAttribute("name") == "unique_id";
                if (flag45)
                {
                    this.unique_id = xe.GetAttribute("value");
                }
                bool flag46 = xe.GetAttribute("name") == "Operator";
                if (flag46)
                {
                    this.Operator = xe.GetAttribute("value");
                }
                bool flag47 = xe.GetAttribute("name") == "EQP_ID";
                if (flag47)
                {
                    this.EQP_ID = xe.GetAttribute("value");
                }
                bool flag48 = xe.GetAttribute("name") == "type1";
                if (flag48)
                {
                    this.type1 = xe.GetAttribute("value");
                }
                bool flag49 = xe.GetAttribute("name") == "type2";
                if (flag49)
                {
                    this.type2 = xe.GetAttribute("value");
                }
                bool flag50 = xe.GetAttribute("name") == "unifomity";
                if (flag50)
                {
                    this.unifomity = xe.GetAttribute("value");
                }
                bool flag51 = xe.GetAttribute("name") == "max_lumi";
                if (flag51)
                {
                    this.max_lumi = xe.GetAttribute("value");
                }
                bool flag52 = xe.GetAttribute("name") == "part_no";
                if (flag52)
                {
                    this.part_no = xe.GetAttribute("value");
                }
                bool flag53 = xe.GetAttribute("name") == "model_no";
                if (flag53)
                {
                    this.model_no = xe.GetAttribute("value");
                }
                bool flag54 = xe.GetAttribute("name") == "fw_version";
                if (flag54)
                {
                    this.fw_version = xe.GetAttribute("value");
                }
                bool flag55 = xe.GetAttribute("name") == "PIS2_check";
                if (flag55)
                {
                    this.PIS2_check = Convert.ToBoolean(xe.GetAttribute("value"));
                }
                bool flag56 = xe.GetAttribute("name") == "PanelPosition";
                if (flag56)
                {
                    this.PanelPosition = xe.GetAttribute("value");
                }
                bool flag57 = xe.GetAttribute("name") == "PanelPositionState";
                if (flag57)
                {
                    this.PanelPositionState = Convert.ToBoolean(xe.GetAttribute("value"));
                }
            }
        }


        public void CreatXML(string path)
        {
            string ConfigPath = Environment.CurrentDirectory + "\\Test.xml";
            bool flag = !File.Exists(ConfigPath);
            if (flag)
            {
                XmlDocument xml = new XmlDocument();
                XmlElement config = xml.CreateElement("Config");
                xml.AppendChild(config);
                XmlElement age = xml.CreateElement("Age");
                age.InnerText = "内容1";
                config.AppendChild(age);
                XmlElement name = xml.CreateElement("Name");
                name.InnerText = "内容2";
                config.AppendChild(name);
                XmlElement address = xml.CreateElement("Address");
                XmlAttribute country = xml.CreateAttribute("Country");
                country.InnerText = "China";
                address.InnerText = "内容3";
                address.Attributes.Append(country);
                config.AppendChild(address);
                XmlElement children = xml.CreateElement("Children");
                children.InnerXml = "内容4";
                address.AppendChild(children);
                xml.Save(ConfigPath);
            }
        }

        public XmlDocument xmlDoc { get; set; } = new XmlDocument();

        public XmlNode xn { get; set; }

        public string path { get; set; }

        public XmlNodeList xnlist { get; set; }
    }
}
