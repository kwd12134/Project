using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class DataHelper
    {
        public static string JudgementModel(string Code)
        {
            switch (Code)
            {
                case "0":
                    return "快速模式";
                case "1":
                    return "pset模式";
                case "2":
                    return "job模式";
                default:
                    return null;
            }
        }
        public static string JudgeERROR(string Error)
        {
            if (Error == null || Error == "")
            {
                return null;
            }
            switch (Error)
            {
                case "0":
                    return "拧紧合格";
                case "00":
                    return "拧紧合格";
                case "01":
                    return "系统故障";
                case "02":
                    return "系统急停";
                case "03":
                    return "总时间超限";
                case "04":
                    return "总角度过大";
                case "05":
                    return "总角度过小";
                case "06":
                    return "反松扭矩过大";
                case "07":
                    return "滑牙";
                case "08":
                    return "浮高";
                default:
                    return Error;
            }
        }

        public static string SystemMalfunctionStatus(string[] Status)
        {
            string Data = Status[0];
            switch (Data)
            {
                case "0":
                    return "设备正常";  
                case "1":
                    return "欠压";
                case "2":
                    return "过压";
                case "3":
                    return "软件过流";
                case "4":
                    return "编码器断线";
                case "5":
                    return "编码器通讯异常";
                case "6":
                    return "超速";
                case "7":
                    return "转速异常";
                case "8":
                    return "工具初始化失败";
                case "9":
                    return "工具型号解析错误";
                case "10":
                    return "工具型号匹配错误";
                case "11":
                    return "IPM故障";
                case "15":
                    return "IQ电流故障";
                case "16":
                    return "摩擦力矩异常";
                case "17":
                    return "母线电流过流";
                case "20":
                    return "与控制器通讯失败";
                case "21":
                    return "控制器报文解析错误";
                case "22":
                    return "电机温度过高";
                default:
                    return null;
            }
        }

    }
}
