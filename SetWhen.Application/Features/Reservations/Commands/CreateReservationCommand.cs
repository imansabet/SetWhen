using MediatR;

namespace SetWhen.Application.Features.Reservations.Commands;
public record CreateReservationCommand(
    Guid ServiceId,
    Guid StaffId,
    DateTime StartTime
) : IRequest<Guid>;