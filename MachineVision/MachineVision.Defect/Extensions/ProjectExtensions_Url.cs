using MachineVision.Defect.Models;
using System.IO;

namespace MachineVision.Defect.Extensions
{
    public static partial class ProjectExtensions
    {
        public static string BasrUrl = AppDomain.CurrentDomain.BaseDirectory + "Products\\";

        /// <summary>
        /// 获取项目的参考点绝对地址
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static string GetReferUrl(this ProjectModel Model)
        {
            string url = $"{BasrUrl}{Model.Name}\\Refer\\";

            if (!Directory.Exists(url))
            {
                Directory.CreateDirectory(url);
            }

            return url;
        }
    }
}
