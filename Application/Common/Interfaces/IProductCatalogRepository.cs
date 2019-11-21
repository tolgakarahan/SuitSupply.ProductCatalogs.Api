using Application.ProductCatalogs.Commands.CreateProductCatalog;
using Application.ProductCatalogs.Commands.DeleteProductCatalog;
using Application.ProductCatalogs.Commands.UpdateProductCatalog;
using Application.ProductCatalogs.Queries.GetProductCatalog;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IProductCatalogRepository
    {
        IQueryable<ProductCatalog> GetProductCatalogs();
        Task<ProductCatalog> GetProductCatalogByIdAsync(GetProductCatalogQuery query);

        Task<int> CreateProductCatalogAsync(CreateProductCatalogCommand command, CancellationToken cancellationToken);

        Task<bool> UpdateProductCatalogAsync(UpdateProductCatalogCommand command, CancellationToken cancellationToken);

        Task<bool> DeleteProductCatalogAsync(DeleteProductCatalogCommand command, CancellationToken cancellationToken);
    }
}
