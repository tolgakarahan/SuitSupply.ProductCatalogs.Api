using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductCatalogs.Queries.GetProductCatalogList
{
    public class GetProductCatalogListQueryHandler : IRequestHandler<GetProductCatalogListQuery, ProductCatalogListVm>
    {
        private readonly IProductCatalogRepository _productCatalogRepository;
        private readonly IMapper _mapper;

        public GetProductCatalogListQueryHandler(IProductCatalogRepository productCatalogRepository, IMapper mapper)
        {
            this._productCatalogRepository = productCatalogRepository;
            this._mapper = mapper;
        }

        public async Task<ProductCatalogListVm> Handle(GetProductCatalogListQuery request, CancellationToken cancellationToken)
        {
            var productCatalogDtos = await _productCatalogRepository.GetProductCatalogs().ProjectTo<ProductCatalogDto>(_mapper.ConfigurationProvider).ToListAsync();

            var vm = new ProductCatalogListVm
            {
                ProductCatalogs = productCatalogDtos
            };

            return vm;
        }
    }
}
