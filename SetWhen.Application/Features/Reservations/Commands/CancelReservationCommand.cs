using MediatR;

namespace SetWhen.Application.Features.Reservations.Commands;
public record CancelReservationCommand(Guid ReservationId) : IRequest;
