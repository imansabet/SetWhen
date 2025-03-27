using Microsoft.EntityFrameworkCore;
using SetWhen.Application.Interfaces;
using SetWhen.Domain.ValueObjects;
using SetWhen.Infrastructure.Persistence;

namespace SetWhen.Infrastructure.Services;
public class StaffAvailabilityQueryService : IStaffAvailabilityQueryService
{
    private readonly AppDbContext _context;

    public StaffAvailabilityQueryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TimeRange>> GetAvailableSlotsAsync(Guid staffId, DateOnly date)
    {
        var dayOfWeek = date.DayOfWeek;

        var availability = await _context.StaffAvailabilities
            .Where(a => a.StaffId == staffId && a.DayOfWeek == dayOfWeek)
            .ToListAsync();

        if (!availability.Any())
            return [];

        var reservations = await _context.Reservations
            .Where(r => r.StaffId == staffId && r.StartTime.Date == date.ToDateTime(TimeOnly.MinValue).Date)
            .Include(r => r.Service)
            .ToListAsync();

        var reservedSlots = reservations
        .Select(r => new TimeRange(
            r.StartTime.TimeOfDay,
             r.StartTime.Add(r.Service.Duration).TimeOfDay
            ))
        .ToList();

        var result = new List<TimeRange>();

        foreach (var slot in availability.Select(a => a.TimeRange))
        {
            var free = slot.ExcludeMany(reservedSlots);
            result.AddRange(free);
        }

        return result;
    }
}
