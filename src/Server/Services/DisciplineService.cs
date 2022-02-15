using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BimKrav.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BimKrav.Server.Services;

public class DisciplineService : IDisciplineService
{
    private readonly BimKravDbContext _context;
    private readonly IMapper _mapper;

    public DisciplineService(BimKravDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Discipline>> GetAllDisciplines()
    {
        var disciplineTbls = await _context.Disciplines.ToListAsync();
        return _mapper.Map<List<Discipline>>(disciplineTbls);
    }
}