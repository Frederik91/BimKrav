using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BimKrav.Api.Services;
using System.ComponentModel.DataAnnotations;
using AzureFunctions.Extensions.Swashbuckle.Attribute;

namespace BimKrav.Api.Functions;

public class PropertyFunctions
{
    private readonly IPropertyService _propertyService;

    public PropertyFunctions(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }

    [FunctionName("Properties")]
    [QueryStringParameter("projectId", "Filter properties  by project", DataType = typeof(int), Required = false)]
    [QueryStringParameter("disciplineId", "Filter properties by discipline", DataType = typeof(int), Required = false)]
    [QueryStringParameter("phaseId", "Filter properties by phase", DataType = typeof(int), Required = false)]

    public async Task<IActionResult> GetAllProperties([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("Get properties request");

        var projectId = req.Query["projectId"].TryParseIntNullable();
        int? phaseId = req.Query["phaseId"].TryParseIntNullable();
        int? disciplineId = req.Query["disciplineId"].TryParseIntNullable();

        var properties = await _propertyService.GetProperties(projectId, phaseId, disciplineId);
        return new OkObjectResult(properties);
    }
}
