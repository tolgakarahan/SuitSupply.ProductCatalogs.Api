using Application.Common.CustomValidators;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace Application.ProductCatalogs.Commands.CreateProductCatalog
{
    public class CreateProductCatalogCommandValidator : CustomAbstractValidator<CreateProductCatalogCommand>
    {
        public CreateProductCatalogCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}
