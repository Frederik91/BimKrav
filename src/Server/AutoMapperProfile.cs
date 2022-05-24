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
        CreateMap<RevitCategoryTbl, RevitCategory>()
            .ForMember(x => x.Disciplines, x => x.MapFrom(y => y.DisciplineRevitCategories.Select(z => z.Discipline)));

        CreateMap<PSetTbl, PSet>();
        CreateMap<PropertyTbl, Property>()
            .ForMember(x => x.RevitCategories, x => x.MapFrom(y => y.RevitCategoryProperties.Select(z => z.RevitCategory)))
            .ForMember(x => x.Comment, x => x.MapFrom(y => y.Comment)) 
            .ForMember(x => x.Description, x => x.MapFrom(y => y.Description))
            .ForMember(x => x.PSets, x => x.MapFrom(y => y.PSetProperties.Select(x => x.PSet)))
            .ForMember(x => x.Phases, x => x.MapFrom(y => MapPhase(y)));

        CreateMap<PhaseTbl, Phase>();
    }

    private static List<string> MapPhase(PropertyTbl propertyTbl)
    {
        var phases = new List<string>();
        var phase = propertyTbl.Phase.FirstOrDefault();
        if (phase is null)
            return new List<string>();

        if (phase.Skisseprosjekt)
            phases.Add("Skisseprosjekt");
        if (phase.Forprosjekt)
            phases.Add("Forprosjekt");
        if (phase.Detaljprosjekt)
            phases.Add("Detaljprosjekt");
        if (phase.Arbeidstegning)
            phases.Add("Arbeidstegning");
        if (phase.Overlevering)
            phases.Add("Overlevering");

        return phases;
    }
}