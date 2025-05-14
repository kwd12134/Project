using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MCMQ
{

    /// <summary>
    /// 描述：表示一个track_out_request对象，用于过站信息。
    /// </summary>
    [Serializable]
    [XmlRoot("trx")]
    public class XmlStationRequest
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [XmlElement("message_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// 类型ID
        /// </summary>
        [XmlElement("type_id")]
        public string TypeId { get; set; }

        /// <summary>
        /// 日志ID
        /// </summary>
        [XmlElement("log_id")]
        public string LogId { get; set; }

        /// <summary>
        /// 面板ID
        /// </summary>
        [XmlElement("panel_id")]
        public string PanelId { get; set; }

        /// <summary>
        /// 站点
        /// </summary>
        [XmlElement("station")]
        public string Station { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [XmlElement("grade")]
        public string Grade { get; set; }

        /// <summary>
        /// 是否报废
        /// </summary>
        [XmlElement("is_scrap")]
        public string IsScrap { get; set; }

        /// <summary>
        /// 是否修复
        /// </summary>
        [XmlElement("is_repair")]
        public string IsRepair { get; set; }

        /// <summary>
        /// 全检标志
        /// </summary>
        [XmlElement("full_test_flag")]
        public string FullTestFlag { get; set; }

        /// <summary>
        /// 不进行过站时的NG标志
        /// </summary>
        [XmlElement("is_ng_without_trackout")]
        public string IsNgWithoutTrackout { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

        /// <summary>
        /// MLP ID
        /// </summary>
        [XmlElement("mlp_id")]
        public string MlpId { get; set; }

        /// <summary>
        /// 夹具ID
        /// </summary>
        [XmlElement("jig_id")]
        public string JigId { get; set; }

        /// <summary>
        /// 端口ID
        /// </summary>
        [XmlElement("port_id")]
        public string PortId { get; set; }

        /// <summary>
        /// 系统参数
        /// </summary>
        [XmlElement("sys_para")]
        public string SysPara { get; set; }

        /// <summary>
        /// 父区域
        /// </summary>
        [XmlElement("p_area")]
        public string PArea { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        [XmlElement("area")]
        public string Area { get; set; }

        /// <summary>
        /// 生产线
        /// </summary>
        [XmlElement("line")]
        public string Line { get; set; }

        [XmlElement("chip_info")]
        public string chip_info { get; set; } = " ";

        /// <summary>
        /// 操作
        /// </summary>
        [XmlElement("operation")]
        public string Operation { get; set; }

        /// <summary>
        /// 下一步操作
        /// </summary>
        [XmlElement("next_operation")]
        public string NextOperation { get; set; }

        /// <summary>
        /// 面板EDID数据
        /// </summary>
        [XmlElement("panel_edid_data")]
        public string PanelEdidData { get; set; } = " ";
    }

}




