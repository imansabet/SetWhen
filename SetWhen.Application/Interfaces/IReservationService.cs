using SetWhen.Domain.Entities;

namespace SetWhen.Application.Interfaces;
public interface IReservationService
{
    Task<Guid> CreateReservationAsync(Guid customerId, Guid serviceId, Guid staffId, DateTime startTime);
    Task CancelReservationAsync(Guid reservationId);
    Task CompleteReservationAsync(Guid reservationId);
    Task ConfirmReservationAsync(Guid reservationId);



}