using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Parameter>> GetParametersInProjectByPhase(string project, string phase, string? disciplineCode)
        {
            var parameters = await _connection.ExecuteQuery<dynamic>($"SELECT PropertyName, GROUP_CONCAT(RevitElement) as Categories, TypeInstans as Level, RevitPropertyType, PropertyGUID FROM `bim`.`z view krav {project}` WHERE {phase} = 1 {(string.IsNullOrEmpty(disciplineCode) ? "" : $"AND DisiplinKode = '{disciplineCode}'")} GROUP BY PropertyName");
            return parameters.Select(x =>
            {
                return new Parameter
                {
                    PropertyName = x.PropertyName,
                    Categories = ReadCategories(x.Categories?.ToString() ?? string.Empty),
                    Level = x.Level,
                    PropertyGUID = string.IsNullOrEmpty(x.PropertyGUID?.ToString()) ? Guid.Empty : Guid.Parse(x.PropertyGUID.ToString()),
                    RevitPropertyType = x.RevitPropertyType
                };
            }).ToList();
        }

        private static List<string> ReadCategories(string x)
        {
            return x.Split(',').Distinct().ToList();
        }
    }
}