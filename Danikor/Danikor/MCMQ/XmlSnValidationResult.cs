using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MCMQ
{
    // 描述：表示一个si300_interface对象，包含验证结果的多个属性。
    [Serializable]
    [XmlRoot("si300_interface")]
    public class XmlSnValidationResult
    {
        // 消息ID
        [XmlElement("message_id")]
        public string MessageId { get; set; }

        // 消息日志ID
        [XmlElement("message_log_id")]
        public string MessageLogId { get; set; }

        // 结果
        [XmlElement("result")]
        public string Result { get; set; }

        // 错误信息
        [XmlElement("error_message")]
        public string ErrorMessage { get; set; }

        // MLP ID
        [XmlElement("mlp_id")]
        public string MlpId { get; set; }

        // WPCB范围
        [XmlElement("wpcb_range")]
        public WpcbRange WpcbRange { get; set; }

        // 第二WPCB范围
        [XmlElement("wpcb_range2")]
        public WpcbRange2 WpcbRange2 { get; set; }

        // PLL时钟上限值
        [XmlElement("pll_clk_upper_value")]
        public string PllClkUpperValue { get; set; }
    }

    [Serializable]
    public class WpcbRange
    {
        // VDD上限值
        [XmlElement("vdd_upper_value")]
        public string VddUpperValue { get; set; }

        // VDD下限值
        [XmlElement("vdd_lower_value")]
        public string VddLowerValue { get; set; }
    }

    [Serializable]
    public class WpcbRange2
    {
        // 结果
        [XmlElement("result")]
        public string Result { get; set; }

        // VDD下限值2
        [XmlElement("vdd_lower_value2")]
        public string VddLowerValue2 { get; set; }
    }
}
