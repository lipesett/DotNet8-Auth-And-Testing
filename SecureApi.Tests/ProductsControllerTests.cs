using Microsoft.AspNetCore.Mvc.Testing;
using SecureApi.Dtos;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SecureApi.Tests
{
    // This class uses IClassFixture to create a single instance of the API in memory
    // that will be shared among all tests of this class. It's more efficient.
    public class ProductsControllerTests : IClassFixture<AuthApiWebAppFactory>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ProductsControllerTests(AuthApiWebAppFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetProducts_WithoutToken_ReturnsUnauthorized()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/products");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetProducts_WithValidToken_ReturnsOk()
        {
            // Arrange
            var client = _factory.CreateClient();

            // First, log in to get a valid JWT token
            var loginDto = new LoginDto { Username = "testuser", Password = "Password123!" };
            var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
            var loginResponse = await client.PostAsync("/api/auth/login", content);
            var loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
            var userDto = JsonSerializer.Deserialize<UserDto>(loginResponseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Use the token to access the protected endpoint
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userDto.Token);

            // Act
            var response = await client.GetAsync("/api/products");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}