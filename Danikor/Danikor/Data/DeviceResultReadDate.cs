using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{

    public class DeviceResultReadDate
    {
        public string 工号{  get; set; }

        public string SN码 {  get; set; }

        public string 执行顺序进度 {  get; set; }

        public string 最终扭矩 {  get; set; }

        public string 最终角度 {  get; set; }

        public string 监控角度 {  get; set; }

        public string 执行时间 {  get; set; }

        public string 拧紧结果状态 {  get; set; }

        public string NG结果 {  get; set; }

    }
}
