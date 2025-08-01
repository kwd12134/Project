using AutoMapper;
using MachineVision.Defect.Models;
using MachineVision.Shared.Services.Tables;

namespace MachineVision.Defect
{
    public class DefectProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public DefectProfile()
        {
            //配置反转,逆向映射
            CreateMap<Project, ProjectModel>().ReverseMap();
            CreateMap<InspecRegion, InspecRegionModel>().ReverseMap();
        }
    }
}
