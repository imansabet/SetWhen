using MediatR;

namespace SetWhen.Application.Features.Reservations.Commands;
public record ConfirmReservationCommand(Guid ReservationId) : IRequest;
