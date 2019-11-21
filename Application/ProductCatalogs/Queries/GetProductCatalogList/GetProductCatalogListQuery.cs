using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCatalogs.Queries.GetProductCatalogList
{
    public class GetProductCatalogListQuery : IRequest<ProductCatalogListVm>
    {
    }
}
