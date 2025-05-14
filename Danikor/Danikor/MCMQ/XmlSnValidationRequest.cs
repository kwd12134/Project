using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MCMQ
{

    // 描述：表示一个si300_interface对象，包含验证SN信息的多个属性。
    [Serializable]
    [XmlRoot("si300_interface")]
    public class XmlSnValidationRequest
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [XmlElement("message_id")]
        public string MessageId { get; set; } =  "";

        /// <summary>
        /// 版本号
        /// </summary>
        [XmlElement("ver")]
        public string Version { get; set; } = "";

        /// <summary>
        /// 功能
        /// </summary>
        [XmlElement("function")]
        public string Function { get; set; } = "";

        /// <summary>
        /// 用户ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; } = "";

        /// <summary>
        /// 系统参数
        /// </summary>
        [XmlElement("sys_para")]
        public string SysPara { get; set; } = "";

        /// <summary>
        /// 父区域
        /// </summary>
        [XmlElement("p_area")]
        public string PArea { get; set; } = "";

        /// <summary>
        /// 区域
        /// </summary>
        [XmlElement("area")]
        public string Area { get; set; } = "";

        /// <summary>
        /// 生产线
        /// </summary>
        [XmlElement("line")]
        public string Line { get; set; } = "";

        /// <summary>
        /// 操作
        /// </summary>
        [XmlElement("operation")]
        public string Operation { get; set; } = "";

        /// <summary>
        /// 批次号
        /// </summary>
        [XmlElement("lot_no")]
        public string LotNo { get; set; } = "";
    }
}
