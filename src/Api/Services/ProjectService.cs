using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BimKrav.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BimKrav.Api.Services;

public class ProjectService : IProjectService
{
    private readonly BimKravDbContext _bimKravDbContext;
    private readonly IMapper _mapper;

    public ProjectService(BimKravDbContext bimKravDbContext, IMapper mapper)
    {
        _bimKravDbContext = bimKravDbContext;
        _mapper = mapper;
    }

    public async Task<List<Project>> GetAllProjects()
    {
        var projectTbls = await _bimKravDbContext.Projects.ToListAsync();
        return _mapper.Map<List<Project>>(projectTbls);
    }
}