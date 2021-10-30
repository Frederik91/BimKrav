using BimKrav.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BimKrav.Client.Services
{
    public interface IPropertyService
    {
        Task<List<Property>> GetProperties(int? projectId, int? phaseId, int? disciplineId);
    }
}