using MediatR;

namespace SetWhen.Application.Features.Reservations.Commands;
public record CompleteReservationCommand(Guid ReservationId) : IRequest;
