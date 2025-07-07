using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Core.TemplateMatch
{
    /// <summary>
    /// 算子的描述信息
    /// </summary>
    public class MethodInfo
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 算子参数
        /// </summary>
        public List<MethodParameter> Parameters { get; set; }

        /// <summary>
        /// 关联算子
        /// </summary>
        public List<string> Predecessors { get; set; }
    }

    /// <summary>
    /// 算子参数描述
    /// </summary>
    public class MethodParameter
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> Parameters { get; set; }
    }
}
