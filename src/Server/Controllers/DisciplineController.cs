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
    public class DisciplineController : Controller
    {
        private readonly ILogger<DisciplineController> _logger;
        private readonly IDisciplineService _disciplineService;

        public DisciplineController(ILogger<DisciplineController> logger, IDisciplineService disciplineService)
        {
            _logger = logger;
            _disciplineService = disciplineService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Discipline), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _disciplineService.GetAllDisciplines());
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to get disciplines", e);
                return Problem(e.Message);
            }
        }
    }
}