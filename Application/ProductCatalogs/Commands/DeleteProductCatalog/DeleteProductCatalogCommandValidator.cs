using Application.Common.CustomValidators;
using FluentValidation;
using FluentValidation.Results;

namespace Application.ProductCatalogs.Commands.DeleteProductCatalog
{
    public class DeleteProductCatalogCommandValidator : AbstractValidator<DeleteProductCatalogCommand>
    {
        public DeleteProductCatalogCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
