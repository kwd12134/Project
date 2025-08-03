using HalconDotNet;
using MachineVision.Defect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.ViewModels.Components
{
    public interface IRegionContext
    {
        RegionContextResult Run(HObject image,InspecRegionModel Model);

        void Import(string Parameter);

        void Dispose();

        /// <summary>
        /// 获取算法的参数设定
        /// </summary>
        /// <returns></returns>
        string GetJsonParameter();

        void UpdateVariationModel(HObject image, InspecRegionModel model);

    }
}
