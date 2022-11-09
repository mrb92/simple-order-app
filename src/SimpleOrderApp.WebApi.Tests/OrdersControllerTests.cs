using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using SimpleOrderApp.Application.NewOrder.Commands.Create;
using SimpleOrderApp.Application.OrderDetail.Command.UpdateVehicleOrder;
using SimpleOrderApp.Domain.Entities;
using SimpleOrderApp.Domain.Entities.Referentials;
using SimpleOrderApp.Infrastructure.Persistence;

using System.Net.Http.Json;

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

            _factory =_factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var dbOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("TestDb");

                    services.AddSingleton(dbOptionsBuilder.Options);
                });
            });
        }

        [Test]
        public async Task GetOrders_Test()
        {
            var client = _factory.CreateClient();

            await SetTestData();

            var response = await client.GetAsync("api/orders");

            Assert.NotNull(response);

            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task GetOrder_Test()
        {
            var client = _factory.CreateClient();

            await SetTestData();

            var response = await client.GetAsync("api/orders/1?orderTypeId=1");

            Assert.NotNull(response);

            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task GetOrder_Types_Test()
        {
            var client = _factory.CreateClient();

            await SetTestData();

            var response = await client.GetAsync("api/orders/types");

            Assert.NotNull(response);

            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task CreateOrder_Test()
        {
            var client = _factory.CreateClient();

            await SetTestData();

            var vehicleId = 1;

            var response = await client.PostAsJsonAsync("api/orders", new CreateOrderCommand
            {
                CustomerName = "Test Customer",
                CustomerPhone = "000-000-000",
                StartDate = new DateTime(),
                OrderTypeId = 1,
                ItemId = vehicleId
            });

            Assert.NotNull(response);

            Assert.True(response.IsSuccessStatusCode);
        }

        private async Task SetTestData()
        {
            var scope = _factory.Server.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

            if (!dbContext.RefVehicleType.Any())
                dbContext.RefVehicleType.Add(new RefVehicleType { Id = 1, Name = "Truck" });

            if (!dbContext.Vehicle.Any())
                dbContext.Vehicle.Add(new Vehicle { Id = 1, Make = "BMW", Model = "3", PricePerDay = 30, TypeId = 3 });

            if (!dbContext.RefOrderType.Any())
                dbContext.RefOrderType.Add(new RefOrderType { Id = 1, Name = "Vehicles" });

            if (!dbContext.Order.Any())
                dbContext.Order.Add(new Order { 
                Id = 1, 
                Title = "Test order", 
                CustomerName = "John Doe", 
                CustomerPhoneNumber = "000-000-000", 
                OrderTypeId = 1, 
                StartDate = new DateTime(), 
                VehicleOrder = new VehicleOrder { VehicleId = 1, PricePerDay = 20, } 
            });

            await dbContext.SaveChangesExAsync();
        }

        [Test]
        public async Task UpdateOrder_Test()
        {
            var client = _factory.CreateClient();


            var response = await client.PutAsJsonAsync("api/orders/vehicle-order", new UpdateVehicleOrderCommand
            {
                Id = 1,
                EndDate = new DateTime(),
                IsTankFull = true,
                IsCarIntact = true
            });

            Assert.NotNull(response);

            response.EnsureSuccessStatusCode();
        }
    }
}