using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.ProductCatalogs.Commands.CreateProductCatalog;
using Application.ProductCatalogs.Commands.DeleteProductCatalog;
using Application.ProductCatalogs.Commands.UpdateProductCatalog;
using Application.ProductCatalogs.Queries.GetProductCatalog;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductCatalogRepository : IProductCatalogRepository
    {
        private readonly ISuitSupplyDbContext _dbContext;

        public ProductCatalogRepository(ISuitSupplyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<ProductCatalog> GetProductCatalogs()
        {
            return _dbContext.ProductCatalogs.AsQueryable();
        }

        public async Task<ProductCatalog> GetProductCatalogByIdAsync(GetProductCatalogQuery query)
        {
            return await _dbContext.ProductCatalogs.FindAsync(query.Id);
        }

        public async Task<int> CreateProductCatalogAsync(CreateProductCatalogCommand command, CancellationToken cancellationToken)
        {
            var productCatalog = new ProductCatalog
            {
                Code = command.Code,
                Name = command.Name,
                Photo = command.Photo,
                Price = command.Price
            };

            _dbContext.ProductCatalogs.Add(productCatalog);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            //The table can have more than one uniqe index 
            //in this case we must know where the exception cames from.
            //catch (Exception ex) when (ex.Message.Contains(ProductCatalogConstants.ProductCatalogCodeIndexName) 
            //    || (ex.InnerException != null && ex.InnerException.Message.Contains(ProductCatalogConstants.ProductCatalogCodeIndexName)))
            //{
            //    throw new CodeExistsException(nameof(ProductCatalog), command.Code);
            //}

            catch (DbUpdateException ex) 
            {
                throw new CodeExistsException(nameof(ProductCatalog), command.Code);
            }
            catch(Exception ex)
            {
                throw;
            }

            return productCatalog.Id;
        }

        public async Task<bool> UpdateProductCatalogAsync(UpdateProductCatalogCommand command, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProductCatalogs.FindAsync(command.Id);

            if (entity == null)
                throw new NotFoundException(nameof(ProductCatalog), command.Id);

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.Photo = command.Photo;
            entity.Price = command.Price;
            entity.LastUpdate = DateTime.Now;

            try
            {
                var result = await _dbContext.SaveChangesAsync(cancellationToken);
                return result > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new CodeExistsException(nameof(ProductCatalog), command.Code);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteProductCatalogAsync(DeleteProductCatalogCommand command, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ProductCatalogs.FindAsync(command.Id);

            if (entity == null)
                throw new NotFoundException(nameof(ProductCatalog), command.Id);

            _dbContext.ProductCatalogs.Remove(entity);

            var result = await _dbContext.SaveChangesAsync(cancellationToken);

            return result > 0;

        }
    }
}
