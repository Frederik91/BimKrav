using BimKrav.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BimKrav.Components.Services;

public class PhaseService : IPhaseService
{
    private readonly HttpClient _httpClient;

    public PhaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Shared.Models.Phase>> GetPhases()
    {
        return await _httpClient.GetFromJsonAsync<List<Shared.Models.Phase>>("Phases") ?? new List<Shared.Models.Phase>();
    }
}
