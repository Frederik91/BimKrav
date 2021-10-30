using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BimKrav.Server.Models.QueryResults;
using BimKrav.Shared.Models;

namespace BimKrav.Server;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProjectPropertiesByPhaseAndDisciplineResult, Property>().ForMember(x => x.Categories, x => x.MapFrom(y => GetCategoryList(y)));
        CreateMap<ProjectTbl, Project>();
        CreateMap<DisciplineTbl, Discipline>();
        CreateMap<PropertyTbl, Property>()
            .ForMember(x => x.Level, x => x.MapFrom(y => y.TypeInstance))
            .ForMember(x => x.Categories, x => x.MapFrom(y => y.RevitCategoryProperties.Select(z => z.RevitCategory.Name)));

        CreateMap<PhaseTbl, Phase>();
    }

    private static List<string> GetCategoryList(ProjectPropertiesByPhaseAndDisciplineResult y)
    {
        return y.Categories.Split(',').Distinct().ToList();
    }
}