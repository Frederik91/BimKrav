using System.Collections.Generic;
using System.Threading.Tasks;
using BimKrav.Shared.Models;

namespace BimKrav.Server.Services
{
    public interface IDisciplineService
    {
        Task<List<Discipline>> GetAllDisciplines();
    }
}