using System.Collections.Generic;
using System.Threading.Tasks;
using BimKrav.Shared.Models;

namespace BimKrav.Server.Services;

public interface IPropertyService
{
    Task<List<Property>> GetPropertiesInProjectByPhase(int projectId, int phaseId, int? disciplineId);
}