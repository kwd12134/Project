using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlCollection
{

    [XmlRoot("trx")]
    public class CCDDataReport
    {
        [XmlElement("trx_name")]
        public string TrxName { get; set; } = "CCDDataRepor";

        [XmlElement("lot_no")]
        public string LotNo { get; set; }

        [XmlElement("type_id")]
        public string TypeID { get; set; } = "I";

        [XmlElement("log_id")]
        public string LogID { get; set; }

        [XmlElement("iary_infos")]
        public IaryInfos IaryInfos { get; set; }

        [XmlElement("lm_user")]
        public string LmUser { get; set; }

        [XmlElement("lm_time")]
        public string LmTime { get; set; }
    }

    public class IaryInfos
    {
        [XmlElement("iary")]
        public List<Iary> Iary { get; set; }
    }

    public class Iary
    {

        [XmlElement("ccd_type")]
        public string Ccd_Tyoe { get; set; }

        [XmlElement("max_lumi")]
        public string MaxLumi { get; set; }

        [XmlElement("unifomity")]
        public string Unifomity { get; set; }

        //[XmlElement("jig_id")]
        //public string JigId { get; set; }

        //[XmlElement("eqp_id")]
        //public string EqpId { get; set; }

        [XmlElement("judge")]
        public string Judge { get; set; }
    }

}
