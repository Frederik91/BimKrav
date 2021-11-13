using AzureFunctions.Extensions.Swashbuckle;
using BimKrav.Api;
using BimKrav.Api.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace BimKrav.Api;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var services = builder.Services;
        services.AddTransient<IProjectService, ProjectService>();
        services.AddTransient<IDisciplineService, DisciplineService>();
        services.AddTransient<IPropertyService, PropertyService>();
        services.AddTransient<IPhaseService, PhaseService>();
        services.AddAutoMapper(typeof(AutoMapperProfile));

        var connectionString = builder.GetContext().Configuration["ConnectionStrings:dbConnection"];
        services.AddDbContext<BimKravDbContext>(x =>
        {
            x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });


        builder.AddSwashBuckle(Assembly.GetExecutingAssembly());
    }
}
