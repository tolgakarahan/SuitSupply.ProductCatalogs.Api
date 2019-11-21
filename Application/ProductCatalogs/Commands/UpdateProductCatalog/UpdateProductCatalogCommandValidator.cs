using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.ProductCatalogs.Commands.UpdateProductCatalog
{
    public class UpdateProductCatalogCommandValidator : CustomAbstractValidator<UpdateProductCatalogCommand>
    {
        public UpdateProductCatalogCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}
