using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentVariable
{
    public class Variable
    {

        public Variable()
        {
            //初始化创建
            for (int i = 1; i < 13; i++)
            {
                LedxVariable.Add(new LEDxVariable() {LED_Name = $"LED{i}",Ima = "0",VF = "0" });
            }
            for (int i = 1; i < 3; i++)
            {
                ntcVariables.Add(new NtcVariable() { NTC_Name = $"NTC{i}"});
            }
            statuVariables.Add(new StatuVariable());
            //statuVariables.RemoveAt(0);   
        }
        /// <summary>
        /// 读取VF I（am）  值
        /// </summary>
        public List<LEDxVariable> LedxVariable { get; set; } = new List<LEDxVariable>();
        /// <summary>
        /// LED_GetNTC_R   读取电阻  与其实时电阻，点亮前 5s  10s
        /// </summary>
        public List<NtcVariable> ntcVariables { get; set; } = new List<NtcVariable>();

        public List<StatuVariable> statuVariables { get; set; } = new List<StatuVariable>();

    }
}
