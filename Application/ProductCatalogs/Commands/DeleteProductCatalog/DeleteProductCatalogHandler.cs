using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductCatalogs.Commands.DeleteProductCatalog
{
    public class DeleteProductCatalogHandler : IRequestHandler<DeleteProductCatalogCommand>
    {
        private readonly IProductCatalogRepository _productCatalogRepository;
        private readonly IMediator _mediator;

        public DeleteProductCatalogHandler(IProductCatalogRepository productCatalogRepository, IMediator mediator)
        {
            this._productCatalogRepository = productCatalogRepository;
            this._mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteProductCatalogCommand request, CancellationToken cancellationToken)
        {
            await _productCatalogRepository.DeleteProductCatalogAsync(request, cancellationToken);

            await _mediator.Publish(new ProductCatalogDeleted() { ProductCatalogId = request.Id }, cancellationToken);

            return Unit.Value;
        }
    }
}
