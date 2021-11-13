using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BimKrav.Api.Services;

namespace BimKrav.Api.Functions;

public class PhaseFunctions
{
    private readonly IPhaseService _phaseService;

    public PhaseFunctions(IPhaseService phaseService)
    {
        _phaseService = phaseService;
    }

    [FunctionName("Phases")]
    public async Task<IActionResult> GetAllPhases([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
    {
        log.LogInformation("Get phases request");

        var phases = await _phaseService.GetAllPhases();
        return new OkObjectResult(phases);
    }
}
