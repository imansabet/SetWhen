using MediatR;
using SetWhen.Domain.Entities;
using SetWhen.Domain.ValueObjects;

namespace SetWhen.Application.Features.StaffAvailabilities.Queries;
public record GetAvailableSlotsQuery(Guid StaffId, DateOnly Date , Guid? ServiceId = null) : IRequest<List<TimeRange>>;
