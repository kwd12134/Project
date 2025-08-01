using MachineVision.Defect.Extensions;
using MachineVision.Defect.ViewModels.Components.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ReferParameter { get; set; }

        /// <summary>
        /// 模版匹配的参考点数据
        /// </summary>
        public TemplateSetting ReferSetting { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 初始化项目参数
        /// </summary>
        public void InitParameter()
        {
            if (!string.IsNullOrWhiteSpace(ReferParameter))
            {
                //初始化参考点的modelid
                ReferSetting = JsonConvert.DeserializeObject<TemplateSetting>(ReferParameter);
                ReferSetting.InitParameter(this.GetReferUrl());
            }
            else
            {
                ReferSetting = new TemplateSetting();
            }
        }
    }
}
