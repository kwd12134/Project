using MachineVision.Defect.Models;
using MachineVision.Shared.Extensions;
using MachineVision.Shared.Services;
using MachineVision.Shared.Services.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Service
{
    public class ProjectService : BaseService
    {
        public ProjectService(IAppMapper appMapper)
        {
            Mapper = appMapper;
        }

        public IAppMapper Mapper { get; }
        /// <summary>
        /// 通过AppMapper使当前ViewModel的Model实体类转换成数据库的实体类
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateAsync(ProjectModel Input)
        {
            var model = Mapper.Map<Project>(Input);
            if (Input.Id > 0)
            {
                var result = await Sqlite.Select<Project>().Where(t => t.Id.Equals(Input.Id)).FirstAsync();
                if (result != null)
                {
                    model.ReferParameter = JsonConvert.SerializeObject(Input.ReferSetting);
                    model.CreateDate = DateTime.Now;
                    model.UpdateDate = DateTime.Now;
                    //.SetDto(model)：将 model（通常是一个 DTO 对象）映射为要更新的字段内容。
                    await Sqlite.Update<Project>()
                        // .SetDto(model)相当于把 本身映射好的model实体类把里面的相同类型名称数据传输到Project中   Data Transfer Object
                        // 从 model 对象中提取属性值，作为“要更新的字段”设置给 SQL 语句使用。
                        .SetDto(model)
                        .Where(q => q.Id == Input.Id)
                        .ExecuteAffrowsAsync();
                }
            }
            else
            {
                var result = await Sqlite.Select<Project>().FirstAsync(q => q.Name.Equals(Input.Name));
                if (!result)
                {
                    model.CreateDate = DateTime.Now;
                    model.UpdateDate = DateTime.Now;
                    await Sqlite.Insert(model).ExecuteAffrowsAsync();
                }
            }
        }

        public async Task DeleteAsync(int Id)
        {
            await Sqlite.Delete<Project>().Where(a => a.Id == Id).ExecuteAffrowsAsync();
        }

        public async Task<List<ProjectModel>> GetListAsync(string FilterText)
        {
            var models = await Sqlite.Select<Project>()
                .Where(q=>q.Name.Contains(FilterText))
                .ToListAsync();
            return Mapper.Map<List<ProjectModel>>(models);
        }

        public async Task<ProjectModel> GetProjectByIdAsync(int Id)
        {
            var result = await Sqlite.Select<Project>().Where(t => t.Id == Id).FirstAsync();
            if (result != null)
            {
                return Mapper.Map<ProjectModel>(result);
            }
                return null;
        }
    }
}
