using MediatR;

namespace SetWhen.Application.Features.StaffAvailabilities.Commands;
public record CreateStaffAvailabilityCommand(
    Guid StaffId,
    DayOfWeek DayOfWeek,
    TimeSpan Start,
    TimeSpan End
) : IRequest;