using BimKrav.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BimKrav.Client.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly HttpClient _httpClient;

        public DisciplineService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Discipline>> GetDisciplines()
        {
            return await _httpClient.GetFromJsonAsync<List<Discipline>>("Discipline") ?? new List<Discipline>();
        }
    }
}
