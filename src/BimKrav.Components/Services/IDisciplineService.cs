using BimKrav.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BimKrav.Components.Services;

public interface IDisciplineService
{
    Task<List<Discipline>> GetDisciplines();
}
