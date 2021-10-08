using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using BimKrav.Server.Services;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace BimKrav.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.AddControllers();
            //services.AddControllersWithViews();
            //services.AddRazorPages();
            
            services.AddTransient(_ => new MySqlConnection(Configuration["ConnectionStrings:DbConnection"]));
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IMySqlDbConnection, MySqlDbConnection>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IDisciplineService, DisciplineService>();
            services.AddTransient<IParameterService, ParameterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger(options => { options.RouteTemplate = "swagger/{documentName}/swagger.json"; });
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            //app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();
                endpoints.MapControllers();
                //endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
