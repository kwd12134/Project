using MachineVision.Shared.Services;
using MachineVision.Shared.Services.Tables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Services
{
    /// <summary>
    /// //注意：class SettingService<T> 泛型类不适合定义 static 单例  数据库部分
    /// </summary>
    public class SettingService : BaseService, ISettingService
    {
        public async Task<Setting> GetSettingAsync()
        {
            var setting = await Sqlite.Select<Setting>().FirstAsync();
            if (setting == null)
            {
                await InsertDefaultSettingAsync();
                return await GetSettingAsync();
            }
            return setting;
        }

        public async Task SaveSetting(Setting input)
        {
            //t：这是一个 参数变量，代表集合中每一个 Setting 实例。
            //=>：Lambda 运算符，读作“映射到”。
            //t.Id.Equals(input.Id)：表示对这个 Setting 实例 t 进行判断，是否它的 Id 等于 input.Id。
            var setting = await Sqlite.Select<Setting>().FirstAsync(t => t.Id.Equals(input.Id));
            if (setting == null)
            {
                //执行插入sql语句
                await Sqlite.Insert(input).ExecuteAffrowsAsync();
            }
            else
            {
                await Sqlite.Update<Setting>()
                    .SetDto(input)
                    .Where(a => a.Id == input.Id)
                    .ExecuteAffrowsAsync();
            }
        }

        private async Task InsertDefaultSettingAsync()
        {
            await Sqlite.Insert(new Setting()
            {
                Language = "zh-CN",
                SkinName = "Light"
            }).ExecuteAffrowsAsync();
        }
    }
}

