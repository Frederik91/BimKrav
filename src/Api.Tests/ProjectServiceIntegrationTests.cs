using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using BimKrav.Server.Services;

namespace BimKrav.Server.Tests
{
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
}