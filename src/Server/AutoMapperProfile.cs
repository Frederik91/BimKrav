using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BimKrav.Server.Models.QueryResults;
using BimKrav.Shared.Models;

namespace BimKrav.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProjectParametersByPhaseAndDisciplineResult, Parameter>().ForMember(x => x.Categories, x => x.MapFrom(y => GetCategoryList(y)));
        }

        private static List<string> GetCategoryList(ProjectParametersByPhaseAndDisciplineResult y)
        {
            return y.Categories.Split(',').Distinct().ToList();
        }
    }
}