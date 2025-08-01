using HalconDotNet;
using MachineVision.Defect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.ViewModels.Components
{
    public interface IRestoreMatchRegion
    {
        void RestorePosition(HObject Image, InspecRegionModel model,double row, double column);
    }
}
