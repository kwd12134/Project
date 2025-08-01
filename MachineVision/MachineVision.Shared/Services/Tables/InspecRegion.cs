using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Shared.Services.Tables
{
    /// <summary>
    /// 检测区域
    /// </summary>
    public class InspecRegion : BaseEntity
    {

        /// <summary>
        ///情况一：一个项目对应多个检测区域
        ///例如，一个机器视觉项目有多个检测区域要设定：上料口、下料口、对位区等。
        /// 数据库中可能有多个记录：
        ///+------------+------------+
        ///| ProjectId  | Name       |
        ///+------------+------------+
        ///|     1      | 区域A      |
        ///|     1      | 区域B      |
        ///|     1      | 区域C      |
        ///+------------+------------+
        ///此时你用 List<InspecRegionModel> 是正确的，必须保留。
        /// 项目ID  
        /// </summary>
        public int ProjectId { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 检测区域设定参数
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// 检测区域模型及其位置参数  通过实体类映射过来
        /// </summary>
        public string MatchParameter { get; set; }
    }
}
