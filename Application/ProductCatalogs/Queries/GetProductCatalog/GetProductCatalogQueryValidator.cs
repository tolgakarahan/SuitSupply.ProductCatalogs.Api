using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCatalogs.Queries.GetProductCatalog
{
    public class GetProductCatalogQueryValidator : AbstractValidator<GetProductCatalogQuery>
    {
        public GetProductCatalogQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
