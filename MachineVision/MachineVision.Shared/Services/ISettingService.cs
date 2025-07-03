using MachineVision.Shared.Services.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Shared.Services
{
    /// <summary>
    /// 系统设置服务
    /// </summary>
    public interface ISettingService
    {
        /// <summary>
        /// 异步/线程读取
        /// </summary>
        /// <returns></returns>
        Task<Setting> GetSettingAsync();
        /// <summary>
        /// 异步/线程读取
        /// </summary>
        /// <returns></returns>
        Task SaveSetting(Setting setting);
    }
}
