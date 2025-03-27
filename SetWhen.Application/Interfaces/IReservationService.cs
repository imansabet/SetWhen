using SetWhen.Domain.Entities;

namespace SetWhen.Application.Interfaces;
public interface IReservationService
{
    Task<Reservation> CreateReservationAsync(Guid customerId, Guid serviceId, Guid staffId, DateTime startTime);
    Task CancelReservationAsync(Guid reservationId);

}