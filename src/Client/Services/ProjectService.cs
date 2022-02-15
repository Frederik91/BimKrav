using BimKrav.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BimKrav.Client.Services;

public class ProjectService : IProjectService
{
    private readonly HttpClient _httpClient;

    public ProjectService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Project>> GetProjects()
    {
        return await _httpClient.GetFromJsonAsync<List<Project>>("Project") ?? new List<Project>();
    }
}
