using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using BimKrav.Server.Models.QueryResults;
using BimKrav.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BimKrav.Server.Services;

public class PropertyService : IPropertyService
{
    private readonly BimKravDbContext _context;
    private readonly IMapper _mapper;

    public PropertyService(BimKravDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Property>> GetPropertiesInProjectByPhase(int projectId, int phaseId, int? disciplineId)
    {
        var phasePropertyIds = await GetPhasePropertyIds(phaseId);
        var projectPropertyIds = await _context.ProjectProperties.Where(x => x.ProjectId == projectId && x.ProjectId != null).Select(x => x.PropertyId ?? 0).ToListAsync();
        var propertyIds = phasePropertyIds.Intersect(projectPropertyIds).ToList();

        var propertyTbls = await GeneratePropertyQuery(propertyIds, disciplineId);

        return _mapper.Map<List<Property>>(propertyTbls);
    }

    private async Task<List<int>> GetPhasePropertyIds(int phaseId)
    {
        var mq1 = _context.PropertyPhase.Where(x => x.Skisseprosjekt)
            .Select(x => new { x.PropertyId, Phase = nameof(x.Skisseprosjekt) });

        var mq2 = _context.PropertyPhase.Where(x => x.Forprosjekt)
            .Select(x => new { x.PropertyId, Phase = nameof(x.Forprosjekt) });

        var mq3 = _context.PropertyPhase.Where(x => x.Detaljprosjekt)
            .Select(x => new { x.PropertyId, Phase = nameof(x.Detaljprosjekt) });

        var mq4 = _context.PropertyPhase.Where(x => x.Arbeidstegning)
            .Select(x => new { x.PropertyId, Phase = nameof(x.Arbeidstegning) });

        var mq5 = _context.PropertyPhase.Where(x => x.Overlevering)
            .Select(x => new { x.PropertyId, Phase = nameof(x.Overlevering) });


        var phase = await _context.Phases.FirstAsync(x => x.Id == phaseId);
        return await mq1.Concat(mq2).Concat(mq3).Concat(mq4).Concat(mq5).Where(x => x.Phase == phase.Name).Select(x => x.PropertyId).ToListAsync();
    }

    private async Task<List<PropertyTbl>> GeneratePropertyQuery(List<int> propertyIds, int? disciplineId)
    {

        if (disciplineId is null)
        {
            return await _context.Properties
                .Where(x => propertyIds.Contains(x.Id))
                .Include(x => x.RevitCategoryProperties)
                .ThenInclude(x => x.RevitCategory)
                .ToListAsync();
        }

        var categories = await _context.Discplines
            .Include(x => x.DisciplineRevitCategories)
            .FirstAsync(x => x.Id == disciplineId);
        var categoryIds = categories.DisciplineRevitCategories.Select(x => x.RevitCategoryId).ToList();

        var q = _context.Properties
            .Where(x => propertyIds.Contains(x.Id))
            .Include(x => x.RevitCategoryProperties)
            .ThenInclude(x => x.RevitCategory);

        var result = await q.ToListAsync();
        foreach (var propertyTbl in result)
        {
            propertyTbl.RevitCategoryProperties = propertyTbl.RevitCategoryProperties.Where(x => categoryIds.Contains(x.RevitCategoryId)).ToList();
        }

        return result;
    }
}