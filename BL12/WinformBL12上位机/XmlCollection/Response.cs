using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlCollection
{
    [XmlRoot("Response")]
    public class Response
    {

        [XmlElement("StreamNo")]
        public string StreamNo { get; set; } = " ";

        [XmlElement("Result")]
        public string Result { get; set; }

        [XmlElement("Param1")]
        public string Param1 { get; set; } = " ";

        [XmlElement("Param2")]
        public string Param2 { get; set; } = " ";

        [XmlElement("Param3")]
        public string Param3 { get; set; } = " ";

        [XmlElement("Param4")]
        public string Param4 { get; set; } = " ";

        [XmlElement("Param5")]
        public string Param5 { get; set; } = " ";

        [XmlElement("Param6")]
        public string Param6 { get; set; } = " ";

        [XmlElement("Param7")]
        public string Param7 { get; set; } = " ";

        [XmlElement("Param8")]
        public string Param8 { get; set; } = " ";

        [XmlElement("Param9")]
        public string Param9 { get; set; } = " ";
    }
}
