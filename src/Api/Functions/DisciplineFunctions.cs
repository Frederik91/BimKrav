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

public class DisciplineFunctions
{
    private readonly IDisciplineService _disciplineService;

    public DisciplineFunctions(IDisciplineService disciplineService)
    {
        _disciplineService = disciplineService;
    }

    [FunctionName("Disciplines")]
    public async Task<IActionResult> GetAllDisciplines([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
    {
        log.LogInformation("Get disciplines request");

        var disciplines = await _disciplineService.GetAllDisciplines();
        return new OkObjectResult(disciplines);
    }
}
