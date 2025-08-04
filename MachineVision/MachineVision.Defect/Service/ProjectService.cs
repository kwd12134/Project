using MachineVision.Defect.Models;
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
        #region 项目管理

        public IAppMapper Mapper { get; }

        /// <summary>
        /// 通过AppMapper使当前ViewModel的Model实体类映射成数据库的实体类
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
        /// <summary>
        /// 任何字符串都包含空字符串。
        /// </summary>
        /// <param name="FilterText"></param>
        /// <returns></returns>
        public async Task<List<ProjectModel>> GetListAsync(string FilterText)
        {
            var models = await Sqlite.Select<Project>()
                .Where(q => q.Name.Contains(FilterText))
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

        #endregion

        #region 检测区域

        /// <summary>
        ///情况一：一个项目对应多个检测区域
        ///例如，一个机器视觉项目有多个检测区域要设定：上料口、下料口、对位区等。
        /// 数据库中可能有多个记录：
        ///+------------+------------+
        ///| ProjectId  | Name       |
        ///+------------+------------+
        ///|     1      | 区域A      |
        ///|     1      | 区域B      |
        ///|     1      | 区域C      |
        ///+------------+------------+
        ///此时你用 List<InspecRegionModel> 是正确的，必须保留。
        ///使用采用List返回数据
        /// </summary>
        public async Task<List<InspecRegionModel>> GetRegionListAsync(int ProjectId)
        {
            var list = await Sqlite.Select<InspecRegion>()
                            .Where(q => q.ProjectId == ProjectId)
                            .ToListAsync();

            return Mapper.Map<List<InspecRegionModel>>(list);
        }

        public async Task CreateRegionAsync(InspecRegionModel input)
        {
            var model = Mapper.Map<InspecRegion>(input);
            await Sqlite.Insert<InspecRegion>(model).ExecuteAffrowsAsync();
        }

        public async Task UpdateRegionAsync(InspecRegionModel input)
        {
            var model = Mapper.Map<InspecRegion>(input);

            model.Parameter = input.Context.GetJsonParameter();
            model.MatchParameter = JsonConvert.SerializeObject(input.MatchSetting);

            await Sqlite.Update<InspecRegion>()
                .SetDto(model)
                .Where(q => q.Id == model.Id)
                .ExecuteAffrowsAsync();
        }

        public async Task DeleteRegionAsync(int Id)



        {
            await Sqlite.Delete<InspecRegion>()
                .Where(q=>q.Id==Id)
                .ExecuteAffrowsAsync();
        }


        #endregion


    }
}
