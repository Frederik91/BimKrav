using BimKrav.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BimKrav.Components.Services;

public interface IPropertyService
{
    Task<List<Property>> GetProperties(int? projectId, int? phaseId, int? disciplineId);
}
