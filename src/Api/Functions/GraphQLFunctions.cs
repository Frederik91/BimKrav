using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BimKrav.Api.Services;
using HotChocolate.AzureFunctions;

namespace BimKrav.Api.Functions;

public class GraphQLFunctions
{
    private readonly BimKravDbContext _dbContext;

    public GraphQLFunctions(BimKravDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [FunctionName("GraphQL")]
    public Task<IActionResult> GraphQL([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "graphql/{**slug}")]
        HttpRequest request, [GraphQL] IGraphQLRequestExecutor executor)
    {
        return executor.ExecuteAsync(request);
    }
}
