//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using System.Net.Http.Json;
//using System.Net;
//using Microsoft.EntityFrameworkCore;
//using SetWhen.Infrastructure.Persistence;
//using SetWhen.Application.Features.Reservations.Commands;
//using FluentAssertions;
//using Xunit;
//using Microsoft.Extensions.DependencyInjection;

//namespace SetWhen.Api.Tests.Integration;
//public class ReservationEndpointTests : IClassFixture<WebApplicationFactory<Program>>
//{
//    private readonly WebApplicationFactory<Program> _factory;

//    public ReservationEndpointTests(WebApplicationFactory<Program> factory)
//    {
//        _factory = factory.WithWebHostBuilder(builder =>
//        {
//            builder.ConfigureServices(services =>
//            {
//                // Replace real DB with InMemory
//                var descriptor = services.SingleOrDefault(
//                    d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
//                if (descriptor != null)
//                    services.Remove(descriptor);

//                services.AddDbContext<AppDbContext>(options =>
//                    options.UseInMemoryDatabase("TestDb"));
//            });
//        });
//    }

//    [Fact]
//    public async Task Post_CreateReservation_Should_Return_201_And_Store_Data()
//    {
//        // Arrange
//        var client = _factory.CreateClient();

//        var command = new CreateReservationCommand(
//            Guid.NewGuid(),
//            Guid.NewGuid(),
//            Guid.NewGuid(),
//            DateTime.UtcNow.AddDays(1)
//        );

//        // Act
//        var response = await client.PostAsJsonAsync("/api/reservations", command);

//        // Assert
//        response.StatusCode.Should().Be(HttpStatusCode.Created);

//        var content = await response.Content.ReadFromJsonAsync<Dictionary<string, Guid>>();
//        content.Should().ContainKey("reservationId");
//        content["reservationId"].Should().NotBeEmpty();
//    }
//}