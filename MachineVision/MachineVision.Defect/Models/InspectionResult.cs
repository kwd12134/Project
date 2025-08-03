using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Models
{
    /// <summary>
    /// 检测结果类
    /// </summary>
    public class InspectionResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public double TimeSpan { get; set; }

        public List<RegionContextResult> ContextResults { get; set; }
    }
}
