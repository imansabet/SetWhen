
using SetWhen.Domain.Entities;
using SetWhen.Domain.Enums;
using SetWhen.Domain.Exceptions;
using Xunit;

namespace SetWhen.Domain.Tests;

public class ReservationTests
{
    [Fact]
    public void Cancel_Should_Set_Status_To_Canceled() 
    {
        // Arrange
        var reservation = new Reservation
            (
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                DateTime.Now.AddDays(1)
            );
        // Act
        reservation.Cancel();

        // Assert
        Assert.Equal(ReservationStatus.Canceled, reservation.Status);
    }
    [Fact]
    public void Complete_Without_Confirm_Should_Throw()
    {
        var reservation = new Reservation(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now.AddDays(1)
        );

        Assert.Throws<BusinessRuleException>(() => reservation.Complete());
    }
    [Fact]
    public void Confirm_Should_Set_Status_To_Confirmed()
    {
        var reservation = new Reservation(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now.AddDays(1)
        );

        reservation.Confirm();

        Assert.Equal(ReservationStatus.Confirmed, reservation.Status);
    }
}
