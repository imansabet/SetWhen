using SetWhen.Domain.ValueObjects;

namespace SetWhen.Application.Interfaces;
public interface IStaffAvailabilityQueryService
{
    Task<List<TimeRange>> GetAvailableSlotsAsync(Guid staffId, DateOnly date);
}