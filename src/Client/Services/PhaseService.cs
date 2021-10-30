using BimKrav.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BimKrav.Client.Services
{
    public class PhaseService : IPhaseService
    {
        private readonly HttpClient _httpClient;

        public PhaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Phase>> GetPhases()
        {
            return await _httpClient.GetFromJsonAsync<List<Phase>>("Phase") ?? new List<Phase>();
        }
    }
}
