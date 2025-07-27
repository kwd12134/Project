using AutoMapper;
using MachineVision.Defect.Models;
using MachineVision.Shared.Services.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
