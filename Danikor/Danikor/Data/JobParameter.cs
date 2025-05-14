using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class JobParameter
    {
        public int Product_Count { get; set; } 

        public int OK_Count { get; set; } 

        public int NG_Count { get; set; } 

        /// <summary>
        /// 拧紧合格率
        /// </summary>
        public int ScrewDownFPY { get; set; }
    }
}
