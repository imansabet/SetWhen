using MediatR;

namespace SetWhen.Application.Features.Reservations.Commands;
public record CreateReservationCommand(
    Guid CustomerId,
    Guid ServiceId,
    Guid StaffId,
    DateTime StartTime
) : IRequest<Guid>; // Guid = ReservationId