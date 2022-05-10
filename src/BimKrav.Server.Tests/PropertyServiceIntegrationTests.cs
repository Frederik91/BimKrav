using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using BimKrav.Server.Services;
using Microsoft.AspNetCore.Components;

namespace BimKrav.Server.Tests;

public class PropertyServiceIntegrationTests : IClassFixture<BimKravWebApplicationFactory>
{
    private readonly BimKravWebApplicationFactory _factory;

    public PropertyServiceIntegrationTests(BimKravWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData(null, null, null)]
    [InlineData(1, null, null)]
    [InlineData(1, 3, null)]
    [InlineData(1, 3, 3)]
    [InlineData(null, 3, 3)]
    [InlineData(null, null, 3)]
    [InlineData(null, 3, null)]
    public async Task GetParameters(int? projectId, int? phaseId, int? disciplineId)
    {
        var scope = _factory.Services.CreateScope();
        var cut = scope.ServiceProvider.GetRequiredService<IPropertyService>();
        var properties = await cut.GetProperties(projectId, phaseId, disciplineId);

        Assert.NotNull(properties);
        Assert.NotEmpty(properties);
        var property = properties.First();
        Assert.NotEmpty(property.RevitCategories);
    }
}
