using SetWhen.Application.DTOs;

namespace SetWhen.Application.Interfaces;
public interface IReservationQueryService
{
    Task<List<ReservationDto>> GetReservationsForUserAsync(Guid userId);
}