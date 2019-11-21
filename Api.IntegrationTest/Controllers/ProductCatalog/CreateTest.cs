using Api.IntegrationTest.Common;
using Application.ProductCatalogs.Commands.CreateProductCatalog;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Api.IntegrationTest.Controllers.ProductCatalog
{
    public class CreateTest
    {
        private readonly TestContext _testContext;

        public CreateTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Create_ValidInput_ShouldReturnIdAndStatusCodeAsync()
        {
            var command = GenerateValidDummyCommandContent();
            var client = _testContext.Client;

            var response = await client.PostAsync("/api/productcatalog", command);
            var content = await response.Content.ReadAsStringAsync();

            Assert.True(response.IsSuccessStatusCode);
            Assert.True(int.TryParse(content, out int id));
        }

        [Fact]
        public async Task Create_AlreadyExistsCode_ShouldReturnConflict()
        {
            var command = GenerateValidDummyCommandContent();
            var client = _testContext.Client;

            var response1 = await client.PostAsync("/api/productcatalog", command);
            var response2 = await client.PostAsync("/api/productcatalog", command);

            Assert.True(response1.IsSuccessStatusCode);
            Assert.True(response2.StatusCode == System.Net.HttpStatusCode.Conflict);
        }

        private StringContent GenerateValidDummyCommandContent()
        {
            var price = (decimal)(new Random().NextDouble() * 100d);
            var command = new CreateProductCatalogCommand
            { Code = Guid.NewGuid().ToString(), Name = "Test", Photo = "photo", Price = price };

            return Utilities.GetRequestContent(command);
        }

    }


}
