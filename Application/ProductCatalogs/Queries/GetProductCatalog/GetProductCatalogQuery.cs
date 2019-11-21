using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCatalogs.Queries.GetProductCatalog
{
    public class GetProductCatalogQuery : IRequest<ProductCatalogVm>
    {
        public int Id { get; set; }
    }
}
