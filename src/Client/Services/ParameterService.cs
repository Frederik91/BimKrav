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

        public async Task<List<Property>> GetParameters(int projectId, int phaseId, int? disciplineId)
        {
            var disciplineQuery = "";
            if (disciplineId is not null)
                disciplineQuery = $"?disciplineId={disciplineId}";
            return await _httpClient.GetFromJsonAsync<List<Property>>($"Property/{projectId}/{phaseId}{disciplineQuery}") ?? new List<Property>();
        }
    }
}
