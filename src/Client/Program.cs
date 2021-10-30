using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MudBlazor.Services;
using System.Threading.Tasks;
using BimKrav.Client.Services;
using Polly;

namespace BimKrav.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient(ConsumedApis.BimKrav, client =>
            {
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/");
            })
                .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10)
                }));

            builder.Services.AddHttpClient<IProjectService, ProjectService>(ConsumedApis.BimKrav);
            builder.Services.AddHttpClient<IDisciplineService, DisciplineService>(ConsumedApis.BimKrav);
            builder.Services.AddHttpClient<IPhaseService, PhaseService>(ConsumedApis.BimKrav);
            builder.Services.AddHttpClient<IPropertyService, PropertyService>(ConsumedApis.BimKrav);

            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}
