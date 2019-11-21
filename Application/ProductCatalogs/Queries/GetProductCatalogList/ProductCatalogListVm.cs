using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCatalogs.Queries.GetProductCatalogList
{
    public class ProductCatalogListVm
    {
        public IList<ProductCatalogDto> ProductCatalogs { get; set; }
    }
}
