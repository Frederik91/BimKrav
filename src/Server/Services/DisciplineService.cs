using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using BimKrav.Server.Tables;
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
        var disciplineTbls = await _context.Discplines.ToListAsync();
        return _mapper.Map<List<Discipline>>(disciplineTbls);
    }
}