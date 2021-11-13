using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BimKrav.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BimKrav.Api.Services;

public class PhaseService : IPhaseService
{
    private readonly BimKravDbContext _bimKravDbContext;
    private readonly IMapper _mapper;

    public PhaseService(BimKravDbContext bimKravDbContext, IMapper mapper)
    {
        _bimKravDbContext = bimKravDbContext;
        _mapper = mapper;
    }

    public async Task<List<Phase>> GetAllPhases()
    {
        var phasesTbl = await _bimKravDbContext.Phases.ToListAsync();
        return _mapper.Map<List<Phase>>(phasesTbl);
    }
}