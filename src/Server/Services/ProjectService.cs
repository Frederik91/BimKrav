using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BimKrav.Shared.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace BimKrav.Server.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMySqlDbConnection _connection;

        public ProjectService(IMySqlDbConnection  connection)
        {
            _connection = connection;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            var projects = await _connection.ExecuteQuery<Project>("SELECT TABLE_NAME as Name FROM information_schema.tables WHERE TABLE_TYPE LIKE 'VIEW' AND TABLE_NAME LIKE 'z view krav%';");
            foreach (var project in projects)
            {
                project.Name = project.Name.Replace("z view krav", "").Trim();
            }
            return projects;
        }
    }
}