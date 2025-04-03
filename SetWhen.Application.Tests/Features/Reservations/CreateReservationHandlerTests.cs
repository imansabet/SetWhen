//using FluentAssertions;
//using Moq;
//using SetWhen.Application.Features.Reservations.Commands;
//using SetWhen.Application.Features.Reservations.Handlers;
//using SetWhen.Application.Interfaces;
//using SetWhen.Domain.Entities;

//namespace SetWhen.Application.Tests.Features.Reservations;

//public class CreateReservationHandlerTests
//{
//    [Fact]
//    public async Task Handle_Should_Create_Reservation_And_Save()
//    {
//        // Arrange
//        var fakeReservation = new Reservation(
//            Guid.NewGuid(),
//            Guid.NewGuid(),
//            Guid.NewGuid(),
//            DateTime.UtcNow.AddDays(1)
//        );

//        var reservationServiceMock = new Mock<IReservationService>();
//        reservationServiceMock
//            .Setup(s => s.CreateReservationAsync(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<DateTime>()))
//            .ReturnsAsync(fakeReservation.Id);

//        var unitOfWorkMock = new Mock<IUnitOfWork>();
//        unitOfWorkMock
//            .Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
//            .Returns(Task.CompletedTask);

//        var handler = new CreateReservationHandler(reservationServiceMock.Object, unitOfWorkMock.Object);
       
//        var command = new CreateReservationCommand(
//            fakeReservation.CustomerId,
//            fakeReservation.ServiceId,
//            fakeReservation.StaffId,
//            fakeReservation.StartTime
//        );

//        // Act
//        var result = await handler.Handle(command, CancellationToken.None);

//        // Assert
//        result.Should().Be(fakeReservation.Id);


//        reservationServiceMock.Verify(s => s.CreateReservationAsync(
//            command.CustomerId, command.ServiceId, command.StaffId, command.StartTime), Times.Once);


//        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

//    }

//}
