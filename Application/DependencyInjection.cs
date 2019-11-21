using Application.Common.Behaviours;
using Application.Common.Interfaces;
using Application.ProductCatalogs.Commands.DeleteProductCatalog;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            //AssemblyScanner.FindValidatorsInAssembly(typeof(ISuitSupplyDbContext).Assembly)
            //.ForEach(result =>
            //{
            //    services.AddTransient(result.InterfaceType, result.ValidatorType);
            //});

            //services.AddTransient<IValidator<DeleteProductCatalogCommand>, 
            //    DeleteProductCatalogCommandValidator>();

            return services;
        }
    }
}
