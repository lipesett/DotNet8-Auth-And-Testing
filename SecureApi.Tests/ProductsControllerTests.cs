using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;
using SecureApi;

namespace SecureApi.Tests
{
    // This class uses IClassFixture to create a single instance of the API in memory
    // that will be shared among all tests of this class. It's more efficient.
    public class ProductsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ProductsControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetProducts_WithoutToken_ReturnsUnauthorized()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/products");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}