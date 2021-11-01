using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BimKrav.Shared.Models;

namespace BimKrav.Server;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
       CreateMap<ProjectTbl, Project>();
        CreateMap<DisciplineTbl, Discipline>();
        CreateMap<RevitCategoryTbl, RevitCategory>();
        CreateMap<PSetTbl, PSet>();
        CreateMap<PropertyTbl, Property>()
            .ForMember(x => x.Comment, x => x.MapFrom(y => y.Comment))
            .ForMember(x => x.Description, x => x.MapFrom(y => y.Description))
            .ForMember(x => x.PSets, x => x.MapFrom(y => y.PSetProperties.Select(x => x.PSet)))
            .ForMember(x => x.RevitCategories, x => x.MapFrom(y => y.RevitCategoryProperties.Select(z => z.RevitCategory)));

        CreateMap<PhaseTbl, Phase>();
    }
}