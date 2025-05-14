using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MCMQ
{
    // 描述：表示一个track_out_request对象，用于响应过站信息。
    [Serializable]
    [XmlRoot("trx")]
    public class XmlStationResponse
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [XmlElement("message_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// 日志ID
        /// </summary>
        [XmlElement("log_id")]
        public string LogId { get; set; }

        /// <summary>
        /// 类型ID
        /// </summary>
        [XmlElement("type_id")]
        public string TypeId { get; set; }

        /// <summary>
        /// 返回代码
        /// </summary>
        [XmlElement("rtn_code")]
        public string RtnCode { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        [XmlElement("rtn_msg")]
        public string RtnMsg { get; set; }

        /// <summary>
        /// 返回代码消息
        /// </summary>
        [XmlElement("rtn_code_msg")]
        public string RtnCodeMsg { get; set; }

        /// <summary>
        /// 返回操作
        /// </summary>
        [XmlElement("rtn_action")]
        public string RtnAction { get; set; }

        /// <summary>
        /// 返回参数
        /// </summary>
        [XmlElement("rtn_param")]
        public string RtnParam { get; set; }

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
        /// 面板ID
        /// </summary>
        [XmlElement("panel_id")]
        public string PanelId { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [XmlElement("grade")]
        public string Grade { get; set; }

        /// <summary>
        /// 等级变化
        /// </summary>
        [XmlElement("grade_change")]
        public string GradeChange { get; set; }

        /// <summary>
        /// 下一步操作
        /// </summary>
        [XmlElement("next_operation")]
        public string NextOperation { get; set; }

        /// <summary>
        /// 提升出
        /// </summary>
        [XmlElement("lift_out")]
        public string LiftOut { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("error_message")]
        public string ErrorMessage { get; set; }
    }
}
