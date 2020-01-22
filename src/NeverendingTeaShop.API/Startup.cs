using System;
using System.IO;
using System.Reflection;
using NeverendingTeaShop.Core.Interfaces.Queries;
using NeverendingTeaShop.Core.Interfaces.Repositories;
using NeverendingTeaShop.Core.ProductItems.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NeverendingTeaShop.Infrastructure;

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
            services.AddScoped<IFetchAllTeasQuery, FetchAllTeasQuery>();
            services.AddScoped<IFetchTeaByIdQuery, FetchTeaByIdQuery>();

            switch (Configuration["PersistenceType"])
            {
                case "postgresql":
                    services.AddPostgreSqlStorageProvider();
                    break;
                default:
                    services.AddInMemoryStorageProvider();
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
        public static void AddInMemoryStorageProvider(this IServiceCollection collection)
        {
            collection.AddScoped<ITeaRepository, SqlTeaRepository>();
            collection.AddDbContext<NeverendingTeaShopContext>(options =>
                options.UseInMemoryDatabase("NeverendingTeaShop")
            );
        }

        public static void AddPostgreSqlStorageProvider(this IServiceCollection collection)
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

        public static void PopulateDatabase(this IServiceCollection serviceCollection, ITeaRepository teaRepository)
        {
            DatabasePopulator.PopulateDatabase(teaRepository);
        }
    }
}