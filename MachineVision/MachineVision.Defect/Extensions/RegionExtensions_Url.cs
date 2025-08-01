using MachineVision.Defect.Models;
using MachineVision.Shared.Services.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Extensions
{
    public static partial class RegionExtensions
    {
        public static string BaseUrl = AppDomain.CurrentDomain.BaseDirectory + "Products\\";

        public static string GetRegionUrl(this InspecRegionModel Region)
        {
            string url = $"{BaseUrl}{Region.ProjectName}\\Regions\\{Region.Name}\\";

            if (!Directory.Exists(url))
            {
                Directory.CreateDirectory(url);
            }

            return url;
        }
    }
}
