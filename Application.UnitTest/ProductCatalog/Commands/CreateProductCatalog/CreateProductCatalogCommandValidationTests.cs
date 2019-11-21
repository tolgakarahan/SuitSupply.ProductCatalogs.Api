using Application.ProductCatalogs.Commands.CreateProductCatalog;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.TestHelper;
using Xunit;

namespace Application.UnitTest.ProductCatalog.Commands.CreateProductCatalog
{
    public class CreateProductCatalogCommandValidationTests
    {
        CreateProductCatalogCommandValidator _validationRules;
        public CreateProductCatalogCommandValidationTests()
        {
            _validationRules = new CreateProductCatalogCommandValidator();
        }
       
        [Fact]
        public void Validate_InvalidInput_ShouldHaveValidationError()
        {
            var createProductCatalogCommand = new CreateProductCatalogCommand();

            _validationRules.ShouldHaveValidationErrorFor(x => x.Code, createProductCatalogCommand);
            _validationRules.ShouldHaveValidationErrorFor(x => x.Name, createProductCatalogCommand);
            _validationRules.ShouldHaveValidationErrorFor(x => x.Price, createProductCatalogCommand);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        public void Validate_InvalidPrice_ShouldHaveValidationError(decimal price)
        {
            var createProductCatalogCommand = new CreateProductCatalogCommand() { Price = price };
            _validationRules.ShouldHaveValidationErrorFor(x => x.Price, createProductCatalogCommand);
        }

        [Fact]
        public void Validate_ValidInput_ShouldPassTheTest()
        {
            var command = new CreateProductCatalogCommand() 
                { Code = "codeTest", Name = "nameTest", Price = 5.5m, Photo = "photoTest" };

            _validationRules.ShouldNotHaveValidationErrorFor(x => x.Code, command);
            _validationRules.ShouldNotHaveValidationErrorFor(x => x.Name, command);
            _validationRules.ShouldNotHaveValidationErrorFor(x => x.Price, command);
            _validationRules.ShouldNotHaveValidationErrorFor(x => x.Photo, command);

        }
    }
}
