using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductCatalogs.Queries.GetProductCatalog
{
    public class GetProductCatalogQueryHandler : IRequestHandler<GetProductCatalogQuery, ProductCatalogVm>
    {
        private readonly IProductCatalogRepository _productCatalogRepository;
        private readonly IMapper _mapper;

        public GetProductCatalogQueryHandler(IProductCatalogRepository productCatalogRepository, IMapper mapper)
        {
            this._productCatalogRepository = productCatalogRepository;
            this._mapper = mapper;
        }

        public async Task<ProductCatalogVm> Handle(GetProductCatalogQuery request, CancellationToken cancellationToken)
        {
            var productCatalog = await _productCatalogRepository.GetProductCatalogByIdAsync(request);

            if (productCatalog == null)
                throw new NotFoundException(nameof(ProductCatalog), request.Id);

            return _mapper.Map<ProductCatalogVm>(productCatalog);
        }
    }
}
