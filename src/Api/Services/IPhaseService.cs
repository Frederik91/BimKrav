using System.Collections.Generic;
using System.Threading.Tasks;
using BimKrav.Shared.Models;

namespace BimKrav.Api.Services;

public interface IPhaseService
{
    Task<List<Phase>> GetAllPhases();
}