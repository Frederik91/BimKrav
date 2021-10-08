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
    public class PhaseController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public Task<IActionResult> Get()
        {
            return Task.FromResult(Ok(new List<string>
            {
                "Skisseprosjekt",
                "Forprosjekt",
                "Detaljprosjekt",
                "Arbeidstegning",
                "Overlevering"
            }) as IActionResult);
        }
    }
}