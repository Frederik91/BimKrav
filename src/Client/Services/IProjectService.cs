using BimKrav.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BimKrav.Client.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjects();
    }
}