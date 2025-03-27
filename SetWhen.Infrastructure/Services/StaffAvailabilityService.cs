using Microsoft.EntityFrameworkCore;
using SetWhen.Application.Interfaces;
using SetWhen.Domain.Entities;
using SetWhen.Domain.Exceptions;
using SetWhen.Domain.ValueObjects;
using SetWhen.Infrastructure.Persistence;

namespace SetWhen.Infrastructure.Services;
public class StaffAvailabilityService : IStaffAvailabilityService
{
    private readonly AppDbContext _context;

    public StaffAvailabilityService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Guid staffId, DayOfWeek dayOfWeek, TimeRange timeRange)
    {
        var overlaps = await _context.StaffAvailabilities
            .Where(a => a.StaffId == staffId && a.DayOfWeek == dayOfWeek)
            .ToListAsync();

        var conflict = overlaps.Any(a => a.TimeRange.Overlaps(timeRange));

        if (conflict)
            throw new BusinessRuleException("The selected time overlaps with an existing availability.");

        var availability = new StaffAvailability(staffId, dayOfWeek, timeRange);

        _context.StaffAvailabilities.Add(availability);
        await _context.SaveChangesAsync();
    }
}