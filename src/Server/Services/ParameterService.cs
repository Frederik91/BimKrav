using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BimKrav.Server.Models.QueryResults;
using BimKrav.Shared.Models;

namespace BimKrav.Server.Services
{
    public class ParameterService : IParameterService
    {
        private readonly IMySqlDbConnection _connection;
        private readonly IMapper _mapper;

        public ParameterService(IMySqlDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
        }

        public async Task<List<Parameter>> GetParametersInProjectByPhase(string project, string phase, string disciplineCode)
        {
            var parameters = await _connection.ExecuteQuery<ProjectParametersByPhaseAndDisciplineResult>($"SELECT PropertyName, GROUP_CONCAT(RevitElement) as Categories, TypeInstans as Level, RevitPropertyType FROM `bim`.`z view krav {project}` WHERE {phase} = 1 AND DisiplinKode = '{disciplineCode}' GROUP BY PropertyName");
            return _mapper.Map<List<Parameter>>(parameters);
        }
    }
}