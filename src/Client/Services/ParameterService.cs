using BimKrav.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BimKrav.Client.Services
{
    public class ParameterService : IParameterService
    {
        private readonly HttpClient _httpClient;

        public ParameterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Parameter>> GetParameters(string project, string phase, string? discipline)
        {
            return await _httpClient.GetFromJsonAsync<List<Parameter>>($"Parameter/{project}/{phase}/{discipline ?? string.Empty}") ?? new List<Parameter>();
        }
    }
}
