using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SetWhen.Infrastructure.Persistence;
using SetWhen.Infrastructure.Services;
using Xunit;

namespace SetWhen.Infrastructure.Tests.Services;

public class ReservationServiceTests
{
    private AppDbContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // isolated
            .Options;

        return new AppDbContext(options);
    }
    [Fact]
    public async Task CreateReservationAsync_Should_Add_Reservation_To_DbContext()
    {
        // Arrange
        var context = CreateInMemoryContext();
        var service = new ReservationService(context);

        var customerId = Guid.NewGuid();
        var serviceId = Guid.NewGuid();
        var staffId = Guid.NewGuid();
        var startTime = DateTime.UtcNow.AddDays(1);

        // Act
        var reservation = await service.CreateReservationAsync(customerId, serviceId, staffId, startTime);
        await context.SaveChangesAsync();

        // Assert
        var inDb = await context.Reservations.FirstOrDefaultAsync(x => x.Id == reservation);
        inDb.Should().NotBeNull();
        inDb.CustomerId.Should().Be(customerId);
        inDb.ServiceId.Should().Be(serviceId);
        inDb.StaffId.Should().Be(staffId);
        inDb.StartTime.Should().Be(startTime);
    }
}
