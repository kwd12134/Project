using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWDHTMmodels
{
    /// <summary>
    /// 通信设备组实体类
    /// </summary>
    public class Device
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 通信组的集合
        /// </summary>
        public List<Group> GroupList { get; set; }
        /// <summary>
        /// 通信状态的标志位
        /// </summary>
        public bool IsConnected { get; set; }
        /// <summary>
        /// 通信连接延迟时间
        /// </summary>
        public int ReConnectTime { get; set; } = 2000;
        /// <summary>
        /// 连接标志位
        /// </summary>
        public bool ReConnectSign { get; set; }
        /// <summary>
        /// 当前变量      键名为当前变量名称      值为当前变量实际值
        /// </summary>
        public Dictionary<string,object> CruuentValue =  new Dictionary<string,object>();

        /// <summary>
        /// 报警的触发和消除事件
        /// </summary>
        public event Action<bool,Variable> AlarmTrigEvent;

        /// <summary>
        /// 更新变量     或者在开启软件的时候从Config里面读取到变量追加到字典里面
        /// </summary>
        /// <param name="variable"></param>
        public void UpdateVariable(Variable variable)
        {
            //包含就更新
            if (CruuentValue.ContainsKey(variable.VarName))
            {
                CruuentValue[variable.VarName] = variable.VarValue;
            }
            else//否则就追加
            {
                CruuentValue.Add(variable.VarName, variable.VarValue);  
            }
            //数据更新随便检测一下报警有没有被触发
            CheckAlarm(variable);

        }
        /// <summary>
        /// 检查报警
        /// </summary>
        /// <param name="variable"></param>
        private void CheckAlarm(Variable variable)
        {
            //当前判断是检测上升沿报警是否为开启状态
            if (variable.PosAlarm)
            {
                //当前如果为TRUE的话  表示存储区的值也为TRUE
                bool CurrentValue = variable.VarValue.ToString() == "True";
                //variable.PosCacheValue==false  表示上一次的状态为fasle
                if (CurrentValue==true&&variable.PosCacheValue==false)
                {
                    //检测到了报警触发
                    AlarmTrigEvent(true, variable);
                }
                //表示存储区的上一个状态的报警触发了    且消除了报警
                if (CurrentValue==false && variable.PosCacheValue == true)
                {
                    //检测到了报警消除
                    AlarmTrigEvent(false, variable);
                }
                //
                variable.PosCacheValue = CurrentValue;
            }

            //当前判断是检测下降沿报警是否为开启状态
            if (variable.NegAlarm)
            {
                //当前如果为TRUE的话  表示存储区的值也为TRUE
                bool CurrentValue = variable.VarValue.ToString() == "True";
                //   NegCacheValue默认为TRUE
                if (CurrentValue == false && variable.NegCacheValue == true)
                {
                    //检测到了报警触发
                    AlarmTrigEvent(true, variable);
                }
                //表示存储区的上一个状态的报警触发了    且消除了报警
                if (CurrentValue == true && variable.NegCacheValue == false)
                {
                    //检测到了报警消除
                    AlarmTrigEvent(false, variable);
                }
                //
                variable.NegCacheValue = CurrentValue;
            }
        }

        /// <summary>
        /// 索引器  获取变量值   根据变量名称
        /// </summary>
        /// <param name="Key"></param>
        /// <returns>返回类型是object   返回值是对应寄存器名称的变量值   </returns>
        public object this[string Key]
        {
            get
            {
                if (CruuentValue.ContainsKey(Key))
                {
                    return CruuentValue[Key];
                }
                return null;
            } 
        }

    }
}
