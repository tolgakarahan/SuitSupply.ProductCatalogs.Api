using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Persistence;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuitSupply.ProductCatalogRestApi;
using System.Net.Http;

namespace Api.IntegrationTest.Common
{
    public class TestContext
    {
        private TestServer _server;
        public HttpClient Client { get; private set; }

        public TestContext()
        {
            SetUpClient();
        }
        private void SetUpClient()
        {
            var host = GetWebHostBuilder().Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var suitSupplyDbContext = services.GetRequiredService<SuitSupplyDbContext>();
                suitSupplyDbContext.Database.Migrate();
            }

            _server = new TestServer(GetWebHostBuilder());

            Client = _server.CreateClient();
        }

        private IWebHostBuilder GetWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                   .UseStartup<Startup>()
                   .UseEnvironment("Test");
        }

    }
}
