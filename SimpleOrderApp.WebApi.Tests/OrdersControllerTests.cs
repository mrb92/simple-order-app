using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleOrderApp.Infrastructure.Persistence;

namespace SimpleOrderApp.WebApi.Tests
{
    /// <summary>
    /// Orders Controller Tests
    /// </summary>
    public class OrdersControllerTests
    {
        private readonly WebApplicationFactory<Program> _factory;

        public OrdersControllerTests()
        {
            _factory = new WebApplicationFactory<Program>();

            _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddDbContext<ApplicationDbContext>(options => options
                        .EnableDetailedErrors()
                        .UseInMemoryDatabase("testDb"));
                });
            });
        }

        [Test]
        public async Task GetOrders_Test()
        {
            var client = _factory.CreateClient();

            var context = _factory.Services.GetService<ApplicationDbContext>();

            context.O

            var response = await client.GetAsync("api/orders");

            Assert.NotNull(response);
        }
    }
}