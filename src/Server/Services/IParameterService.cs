using System.Collections.Generic;
using System.Threading.Tasks;
using BimKrav.Shared.Models;

namespace BimKrav.Server.Services
{
    public interface IParameterService
    {
        Task<List<Parameter>> GetParametersInProjectByPhase(string project, string phase, string disciplineCode);
    }
}