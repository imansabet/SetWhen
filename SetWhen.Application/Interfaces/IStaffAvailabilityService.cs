using SetWhen.Domain.ValueObjects;

namespace SetWhen.Application.Interfaces;
public interface IStaffAvailabilityService
{
    Task CreateAsync(Guid staffId, DayOfWeek dayOfWeek, TimeRange timeRange);
}