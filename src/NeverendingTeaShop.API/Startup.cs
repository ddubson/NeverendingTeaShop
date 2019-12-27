using System;
using System.IO;
using System.Reflection;
using NeverendingTeaShop.Application.Interfaces.Queries;
using NeverendingTeaShop.Application.Interfaces.Repositories;
using NeverendingTeaShop.Persistence.InMemory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NeverendingTeaShop.Application.Teas.Queries;

namespace NeverendingTeaShop.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IFetchAllTeasQuery<JsonResult>, FetchAllTeasQuery<JsonResult>>();
            services.AddSingleton<IFetchTeaByIdQuery, FetchTeaByIdQuery>();
            
            switch (Configuration["PersistenceType"])
            {
                case "postgresql":
                    services.AddPostgreSqlRepositories();
                    break;
                default:
                    services.AddH2Repositories();
                    break;
            }

            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "NeverendingTeaShop v1"); });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }

    public static class RepositoriesExtensions
    {
        public static void AddH2Repositories(this IServiceCollection collection)
        {
            collection.AddSingleton<ITeaRepository, InMemoryTeaRepository>();
        }

        public static void AddPostgreSqlRepositories(this IServiceCollection collection)
        {
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static void AddSwagger(this IServiceCollection collection)
        {
            collection.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo {Title = "NeverendingTeaShop API", Version = "v1"});
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                }
            );
        }
    }
}