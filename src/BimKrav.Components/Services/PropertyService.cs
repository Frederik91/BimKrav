using BimKrav.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BimKrav.Components.Services;

public class PropertyService : IPropertyService
{
    private readonly HttpClient _httpClient;

    public PropertyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Property>> GetProperties(int? projectId, int? phaseId, int? disciplineId)
    {
        var queries = new List<string>();
        if (projectId is not null)
            queries.Add($"projectId={projectId}");
        if (phaseId is not null)
            queries.Add($"phaseId={phaseId}");
        if (disciplineId is not null)
            queries.Add($"disciplineId={disciplineId}");

        var query = string.Empty;
        if (queries.Any())
        {
            query += "?";
            query += string.Join("&", queries);
        }

        return await _httpClient.GetFromJsonAsync<List<Property>>($"Properties{query}") ?? new List<Property>();
    }
}
