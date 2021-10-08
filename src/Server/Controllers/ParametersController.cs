using BimKrav.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BimKrav.Server.Services;
using BimKrav.Shared.Models;
using Microsoft.AspNetCore.Http;

namespace BimKrav.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParametersController : ControllerBase
    {
        private readonly ILogger<ParametersController> _logger;
        private readonly IParameterService _parameterService;

        public ParametersController(ILogger<ParametersController> logger, IParameterService parameterService)
        {
            _logger = logger;
            _parameterService = parameterService;
        }

        [HttpGet("/{project}/{phase}/{disciplineCode}")]
        [ProducesResponseType(typeof(List<Parameter>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProjectPhaseParameters(string project, string phase, string disciplineCode)
        {
            try
            {
                return Ok(await _parameterService.GetParametersInProjectByPhase(project, phase, disciplineCode));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return Problem(e.Message);
            }
        }
    }
}
