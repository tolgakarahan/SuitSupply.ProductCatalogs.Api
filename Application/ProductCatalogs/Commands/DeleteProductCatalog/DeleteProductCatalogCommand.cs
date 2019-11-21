using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCatalogs.Commands.DeleteProductCatalog
{
    public class DeleteProductCatalogCommand : IRequest
    {
        public int Id { get; set; }
    }
}
