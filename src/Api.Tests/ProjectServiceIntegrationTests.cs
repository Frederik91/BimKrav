using System.Threading.Tasks;
using BimKrav.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BimKrav.Server.Tests;

public class ProjectServiceIntegrationTests : IClassFixture<BimKravWebApplicationFactory>
{
    private readonly BimKravWebApplicationFactory _factory;

    public ProjectServiceIntegrationTests(BimKravWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAllProjects()
    {
        using var scope = _factory.Services.CreateScope();
        var cut = scope.ServiceProvider.GetService<IProjectService>();
        var projects = await cut.GetAllProjects();

        Assert.NotNull(projects);
        Assert.NotEmpty(projects);
    }
}
