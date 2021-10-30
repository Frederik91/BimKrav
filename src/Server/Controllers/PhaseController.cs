using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BimKrav.Server.Services;
using BimKrav.Shared;
using BimKrav.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BimKrav.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhaseController : Controller
{
    private readonly IPhaseService _phaseService;
    private readonly ILogger<PhaseController> _logger;

    public PhaseController(IPhaseService phaseService, ILogger<PhaseController> logger)
    {
        _phaseService = phaseService;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var phases = await _phaseService.GetAllPhases();
            return Ok(phases);
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to get phases. {exception}", e);
            return BadRequest("Failed to get phases.\n" + e.Message);
        }
    }
}