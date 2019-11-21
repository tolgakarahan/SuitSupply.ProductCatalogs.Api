using Application.Common.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuitSupply.ProductCatalogRestApi.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddSwaggerDocument(configure =>
            {
                configure.Title = "Suit Supply Product Catalog Api";
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();

            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ISuitSupplyDbContext>());

            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(x => x.ErrorMessage)).ToList();

                    var result = JsonConvert.SerializeObject(new DefaultExceptionDto() { Errors = errors });

                    return new BadRequestObjectResult(result);
                };
            });

            return services;
        }
    }
}
