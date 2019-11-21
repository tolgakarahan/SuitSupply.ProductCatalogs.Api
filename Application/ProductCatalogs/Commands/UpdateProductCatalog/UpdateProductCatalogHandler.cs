using Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductCatalogs.Commands.UpdateProductCatalog
{
    public class UpdateProductCatalogHandler : IRequestHandler<UpdateProductCatalogCommand>
    {

        private readonly IProductCatalogRepository _productCatalogRepository;
        private readonly IMediator _mediator;

        public UpdateProductCatalogHandler(IProductCatalogRepository productCatalogRepository, IMediator mediator)
        {
            _productCatalogRepository = productCatalogRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(UpdateProductCatalogCommand request, CancellationToken cancellationToken)
        {
            await _productCatalogRepository.UpdateProductCatalogAsync(request, cancellationToken);

            await _mediator.Publish(new ProductCatalogUpdated() { ProductCatalogId = request.Id });

            return Unit.Value;
        }
    }
}
