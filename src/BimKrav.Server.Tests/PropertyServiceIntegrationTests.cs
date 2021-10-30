using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using BimKrav.Server.Services;

namespace BimKrav.Server.Tests
{
    public class PropertyServiceIntegrationTests : IClassFixture<BimKravWebApplicationFactory>
    {
        private readonly BimKravWebApplicationFactory _factory;

        public PropertyServiceIntegrationTests(BimKravWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetProjectParameters()
        {
            var scope = _factory.Services.CreateScope();
            var cut = scope.ServiceProvider.GetService<IPropertyService>();
            var noDisciplineProperties = await cut.GetPropertiesInProjectByPhase(1, 4, null);
            var properties = await cut.GetPropertiesInProjectByPhase(1, 4, 3);

            Assert.NotNull(properties);
            Assert.NotEmpty(properties);
            var noDisciplineProperty = noDisciplineProperties.First();
            var property = properties.First();
            Assert.NotEmpty(noDisciplineProperty.Categories);
            Assert.NotEmpty(property.Categories);
            Assert.True(noDisciplineProperty.Categories.Count > property.Categories.Count);
        }
    }
}