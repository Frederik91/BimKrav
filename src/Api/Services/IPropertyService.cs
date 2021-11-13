using System.Collections.Generic;
using System.Threading.Tasks;
using BimKrav.Shared.Models;

namespace BimKrav.Api.Services;

public interface IPropertyService
{
    Task<List<Property>> GetProperties(int? projectId, int? phaseId, int? disciplineId);
}