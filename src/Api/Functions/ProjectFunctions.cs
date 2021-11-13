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

public class ProjectFunctions
{
    private readonly IProjectService _projectService;

    public ProjectFunctions(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [FunctionName("Projects")]
    public async Task<IActionResult> GetAllProjects([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
    {
        log.LogInformation("Get projects request");

        var projects = await _projectService.GetAllProjects();
        return new OkObjectResult(projects);
    }
}
