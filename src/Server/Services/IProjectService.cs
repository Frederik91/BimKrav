using System.Collections.Generic;
using BimKrav.Shared.Models;
using System.Threading.Tasks;

namespace BimKrav.Server.Services;

public interface IProjectService
{
    Task<List<Project>> GetAllProjects();
}