using BimKrav.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BimKrav.Client.Services
{
    public interface IParameterService
    {
        Task<List<Parameter>> GetParameters(string project, string phase, string? discipline);
    }
}