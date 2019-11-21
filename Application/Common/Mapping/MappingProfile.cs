using Application.ProductCatalogs.Queries.GetProductCatalog;
using Application.ProductCatalogs.Queries.GetProductCatalogList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Linq;
using System.Reflection;

namespace Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCatalog, ProductCatalogVm>();
            CreateMap<ProductCatalog, ProductCatalogDto>();
        }
    }
}
