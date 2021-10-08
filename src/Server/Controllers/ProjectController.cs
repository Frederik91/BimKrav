using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BimKrav.Server.Services;
using BimKrav.Shared;
using BimKrav.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BimKrav.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projectService;

        public ProjectController(ILogger<ProjectController> logger, IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Project>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _projectService.GetAllProjects());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return Problem(e.Message);
            }
        }
    }
}