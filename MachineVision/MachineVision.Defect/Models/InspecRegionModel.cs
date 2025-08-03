using MachineVision.Defect.Extensions;
using MachineVision.Defect.ViewModels.Components;
using MachineVision.Defect.ViewModels.Components.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Models
{
    public class InspecRegionModel : IDisposable
    {
        public int Id { get; set; }

        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }


        public string Name { get; set; }

        /// <summary>
        /// 检测区域设定参数   (JSON)
        /// </summary>
        public string Parameter { get; set; }


        /// <summary>
        /// 检测区域模型及其位置参数  通过实体类映射过来 (JSON)
        /// </summary>
        public string MatchParameter { get; set; }

        /// <summary>
        /// 检测区域的模型及其绘制参数对象
        /// </summary>
        public TemplateSetting MatchSetting { get; set; }

        /// <summary>
        /// 检测区域服务  每一个区域ROI都有对应的一个算法接口进行计算
        /// </summary>
        [JsonIgnore]
        public IRegionContext Context { get; set; }

        /// <summary>
        /// 初始化模型id与名称地址,还有ROI坐标参数与宽高
        /// </summary>
        public void InitRegionContext()
        {
            if (!string.IsNullOrWhiteSpace(MatchParameter))
            {
                MatchSetting = JsonConvert.DeserializeObject<TemplateSetting>(MatchParameter);
            }
            else
            {
                MatchSetting = new TemplateSetting();
            }

            Context = this.GetRegionContext();

            if (Context is LocalDeformableContext context)
            {
                context.InitStandardId(this.GetRegionUrl());
            }

            string Path = this.GetRegionUrl();
            MatchSetting.InitParameter(Path);

        }

        /// <summary>
        /// 因为Context没有注册到容器中使用需要手动释放
        /// </summary>
        public void Dispose()
        {
            Context?.Dispose();
            MatchSetting?.Dispose();

            MatchSetting = null;
            MatchParameter = string.Empty;
            Parameter = string.Empty;
        }

    }
}
