using BimKrav.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BimKrav.Client.Services
{
    public interface IParameterService
    {
        Task<List<Property>> GetParameters(int projectId, int phaseId, int? disciplineId);
    }
}