using System.Collections.Generic;
using System.Xml.Serialization;

namespace MCMQ
{
    [XmlRoot("transaction")]
    public class XmlData
    {
        [XmlElement("trx_id")]
        public string TrxId { get; set; } = string.Empty;

        [XmlElement("trx_name")]
        public string TrxName { get; set; } = string.Empty;

        [XmlElement("type_id")]
        public string TypeId { get; set; } = string.Empty;

        [XmlElement("system_byte")]
        public string SystemByte { get; set; } = string.Empty;

        [XmlElement("time_stamp")]
        public string TimeStamp { get; set; } = string.Empty;

        [XmlElement("publisher")]
        public string Publisher { get; set; } = string.Empty;

        [XmlElement("control_group")]
        public string ControlGroup { get; set; } = string.Empty;

        [XmlElement("factor")]
        public Factor Factor { get; set; } = new Factor();

        [XmlElement("data")]
        public Data Data { get; set; } = new Data();
    }

    public class Factor
    {
        [XmlElement("factor_item")]
        public List<FactorItem> FactorItems { get; set; }
    }

    public class FactorItem
    {
        [XmlElement("factor_name")]
        public string FactorName { get; set; } = string.Empty;

        [XmlElement("factor_value")]
        public string FactorValue { get; set; } = string.Empty;
    }

    public class Data
    {
        [XmlElement("raw_data_value")]
        public RawDataValue RawDataValue { get; set; }
    }

    public class RawDataValue
    {
        [XmlAttribute("list")]
        public string List { get; set; }

        [XmlAttribute("delimiter")]//   分隔符
        public string Delimiter { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

}
