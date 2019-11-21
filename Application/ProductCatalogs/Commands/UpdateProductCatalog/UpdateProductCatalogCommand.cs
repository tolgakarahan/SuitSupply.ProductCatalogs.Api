using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCatalogs.Commands.UpdateProductCatalog
{
    public class UpdateProductCatalogCommand : IRequest
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
    }
}
