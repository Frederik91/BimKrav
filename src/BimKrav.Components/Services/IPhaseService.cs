using BimKrav.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BimKrav.Components.Services;

public interface IPhaseService
{
    Task<List<Shared.Models.Phase>> GetPhases();
}
