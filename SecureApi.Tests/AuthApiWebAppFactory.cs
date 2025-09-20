using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecureApi.Data;
using SecureApi.Models;
using System.Linq;

namespace SecureApi.Tests
{
    public class AuthApiWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly SqliteConnection _connection;

        public AuthApiWebAppFactory()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlite(_connection);
                });
            });
        }

        public async Task InitializeAsync()
        {
            await _connection.OpenAsync();

            using (var scope = Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppDbContext>();
                var userManager = scopedServices.GetRequiredService<UserManager<AppUser>>();

                await db.Database.MigrateAsync();

                var testUser = new AppUser { UserName = "testuser", Email = "test@example.com" };
                await userManager.CreateAsync(testUser, "Password123!");
            }
        }

        public new async Task DisposeAsync()
        {
            await _connection.CloseAsync();
            await base.DisposeAsync();
        }
    }
}