using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCatalogs.Commands.CreateProductCatalog
{
    public class CreateProductCatalogCommand : IRequest<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
    }
}
