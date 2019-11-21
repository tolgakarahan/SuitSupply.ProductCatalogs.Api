using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCatalogs.Queries.GetProductCatalogList
{
    public class ProductCatalogDto 
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
