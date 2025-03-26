using MediatR;
using SetWhen.Application.DTOs;

namespace SetWhen.Application.Features.Reservations.Queries;
public record GetUserReservationsQuery(Guid UserId) : IRequest<List<ReservationDto>>;
