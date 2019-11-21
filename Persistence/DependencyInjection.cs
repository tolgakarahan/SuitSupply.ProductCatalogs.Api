using Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var _dbSettingName = "SuitSupplyDatabase";

            if (environment.EnvironmentName == "Test")
            {
                _dbSettingName = "SuitSupplyDatabaseTest";
                //services.AddEntityFrameworkInMemoryDatabase();
                //services.AddDbContext<SuitSupplyDbContext>(options =>
                //   options.UseInMemoryDatabase("InMemoryDbForTest"));
            }

            services.AddDbContext<SuitSupplyDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString(_dbSettingName)));

            services.AddScoped<ISuitSupplyDbContext, SuitSupplyDbContext>();

            services.AddScoped<IProductCatalogRepository, ProductCatalogRepository>();

            return services;
        }
    }
}
