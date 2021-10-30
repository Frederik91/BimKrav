using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using BimKrav.Server.Services;
using BimKrav.Shared.Models;
using Microsoft.AspNetCore.Http;

namespace BimKrav.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : Controller
{
    private readonly ILogger<PropertyController> _logger;
    private readonly IPropertyService _parameterService;

    public PropertyController(ILogger<PropertyController> logger, IPropertyService parameterService)
    {
        _logger = logger;
        _parameterService = parameterService;
    }

    [HttpGet("{project}/{phase}")]
    [ProducesResponseType(typeof(Property), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetProjectPhaseProperties(int project, int phase, int? disciplineId)
    {
        try
        {
            return Ok(await _parameterService.GetPropertiesInProjectByPhase(project, phase, disciplineId));
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to get properties", e);
            return Problem(e.Message);
        }
    }
}