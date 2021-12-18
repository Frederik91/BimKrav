using BimKrav.Api.Tables;
using HotChocolate;
using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimKrav.Api;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<ProjectTbl> GetProjects([Service] BimKravDbContext dbContext) => dbContext.Projects.AsQueryable();

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<PhaseTbl> GetPhases([Service] BimKravDbContext dbContext) => dbContext.Phases.AsQueryable();

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<DisciplineTbl> GetDisciplines([Service] BimKravDbContext dbContext) => dbContext.Disciplines.AsQueryable();

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<PropertyTbl> GetProperties([Service] BimKravDbContext dbContext) => dbContext.Properties.AsQueryable();

}
