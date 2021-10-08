using System.Collections.Generic;
using System.Threading.Tasks;
using BimKrav.Shared.Models;

namespace BimKrav.Server.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly IMySqlDbConnection _connection;

        public DisciplineService(IMySqlDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Discipline>> GetAllDisciplines()
        {
            var disciplines = await _connection.ExecuteQuery<Discipline>("SELECT ID_Dicipline as Id, DiciplineName as Name, DisiplinKode as Code FROM bim.tbldicipline;");
            return disciplines;
        }
    }
}