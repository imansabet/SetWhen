using MediatR;
using SetWhen.Domain.ValueObjects;

namespace SetWhen.Application.Features.StaffAvailabilities.Queries;
public record GetAvailableSlotsQuery(Guid StaffId, DateOnly Date) : IRequest<List<TimeRange>>;
