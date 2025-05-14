using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MCMQ
{
    // 描述：表示一个trx对象，用于上报数据。
    [Serializable]
    [XmlRoot("trx")]
    public class XmlDataReport
    {
        /// <summary>
        /// 事务名称
        /// </summary>
        [XmlElement("trx_name")]
        public string TrxName { get; set; } = " ";  

        /// <summary>
        /// 类型ID
        /// </summary>
        [XmlElement("type_id")]
        public string TypeId { get; set; } = " ";

        /// <summary>
        /// 缩写号
        /// </summary>
        [XmlElement("abbr_no")]
        public string AbbrNo { get; set; } = " ";

        /// <summary>
        /// 机台ID
        /// </summary>
        [XmlElement("chamber_id")]
        public string ChamberId { get; set; } = " ";

        /// <summary>
        /// 数据时钟
        /// </summary>
        [XmlElement("data_clock")]
        public string DataClock { get; set; } = " ";

        /// <summary>
        /// 设备ID
        /// </summary>
        [XmlElement("eqp_id")]
        public string EqpId { get; set; } = " ";

        /// <summary>
        /// 设备运行ID
        /// </summary>
        [XmlElement("eqp_run_id")]
        public string EqpRunId { get; set; } = " ";

        // 玻璃开始时间
        [XmlElement("glass_start_time")]
        public string GlassStartTime { get; set; } = " ";

        /// <summary>
        /// 玻璃结束时间
        /// </summary>
        [XmlElement("glass_end_time")]
        public string GlassEndTime { get; set; } = " ";

        /// <summary>
        /// 上次维护时间
        /// </summary>
        [XmlElement("lm_time")]
        public string LmTime { get; set; } = " ";

        /// <summary>
        /// 登录时间
        /// </summary>
        [XmlElement("logon_time")]
        public string LogonTime { get; set; } = " ";

        /// <summary>
        /// 批次ID
        /// </summary>
        [XmlElement("lot_id")]
        public string LotId { get; set; } = " ";

        /// <summary>
        /// 批次运行ID
        /// </summary>
        [XmlElement("lot_run_id")]
        public string LotRunId { get; set; } = " ";

        /// <summary>
        /// 模型号
        /// </summary>
        [XmlElement("model_no")]
        public string ModelNo { get; set; } = " ";

        /// <summary>
        /// 操作ID
        /// </summary>
        [XmlElement("op_id")]
        public string OpId { get; set; } = " ";

        /// <summary>
        /// 产品代码
        /// </summary>
        [XmlElement("product_code")]
        public string ProductCode { get; set; } = " ";

        /// <summary>
        /// 配方ID
        /// </summary>
        [XmlElement("recipe_id")]
        public string RecipeId { get; set; } = " ";

        /// <summary>
        /// FOUP ID
        /// </summary>
        [XmlElement("foup_id")]
        public string FoupId { get; set; } = " ";

        /// <summary>
        /// 序列配方ID
        /// </summary>
        [XmlElement("seq_recipe_id")]
        public string SeqRecipeId { get; set; } = " ";

        /// <summary>
        /// 槽位计数
        /// </summary>
        [XmlElement("slot_count")]
        public string SlotCount { get; set; } = " ";

        /// <summary>
        /// 片材ID
        /// </summary>
        [XmlElement("sheet_id")]
        public string SheetId { get; set; } = " ";

        /// <summary>
        /// 槽位号
        /// </summary>
        [XmlElement("slot_no")]
        public string SlotNo { get; set; } = " ";

        /// <summary>
        /// 运行总结数据
        /// </summary>
        [XmlElement("RunSummary_Str")]
        public RunSummaryString runSummaryString { get; set; }

        [XmlAnyElement("RunSummary")]
        public XmlElement RunSummary { get; set; }
    }

    /// <summary>
    /// 描述：表示一个RunSummary_Str对象，包含运行总结数据。
    /// </summary>
    [Serializable]
    public class RunSummaryString
    {
        /// <summary>
        /// 螺丝结果
        /// </summary>
        [XmlElement("SCREW_RESULT")]
        public string ScrewResult { get; set; } = " ";

        /// <summary>
        /// 螺丝单位
        /// </summary>
        [XmlElement("SCREW_UNIT")]
        public string ScrewUnit { get; set; } = " ";

        /// <summary>
        /// 时间单位
        /// </summary>
        [XmlElement("TIME_UNIT")]
        public string TimeUnit { get; set; } = " ";
    }

}
