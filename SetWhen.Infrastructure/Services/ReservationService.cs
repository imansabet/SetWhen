using Microsoft.EntityFrameworkCore;
using SetWhen.Application.Interfaces;
using SetWhen.Domain.Entities;
using SetWhen.Domain.Exceptions;
using SetWhen.Domain.ValueObjects;
using SetWhen.Infrastructure.Persistence;

namespace SetWhen.Infrastructure.Services;
public class ReservationService : IReservationService
{
    private readonly AppDbContext _context;

    public ReservationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateReservationAsync(Guid customerId, Guid serviceId, Guid staffId, DateTime startTime)
    {
        var service = await _context.Services.FindAsync(serviceId);
        if (service is null)
            throw new NotFoundException("Service not found.");


        var endTime = startTime.Add(service.Duration);
        var requestedRange = new TimeRange(startTime.TimeOfDay, endTime.TimeOfDay);
        var date = DateOnly.FromDateTime(startTime);

        var dayOfWeek = startTime.DayOfWeek;
        var availabilities = await _context.StaffAvailabilities
            .Where(a => a.StaffId == staffId && a.DayOfWeek == dayOfWeek)
            .ToListAsync();

        if (!availabilities.Any())
            throw new BusinessRuleException("Staff is not working on this day.");

        var reservations = await _context.Reservations
        .Where(r => r.StaffId == staffId && r.StartTime.Date == startTime.Date)
        .Include(r => r.Service)
        .ToListAsync();

        var reservedRanges = reservations
        .Select(r => new TimeRange(
            r.StartTime.TimeOfDay,
            r.StartTime.Add(r.Service.Duration).TimeOfDay
        )).ToList();

        var availableRanges = availabilities
       .SelectMany(a => a.TimeRange.ExcludeMany(reservedRanges))
       .ToList();

        var isAvailable = availableRanges.Any(free =>
        requestedRange.Start >= free.Start && requestedRange.End <= free.End);

        if (!isAvailable)
            throw new BusinessRuleException("This time is not available for reservation.");
        
        var reservation = new Reservation(customerId, serviceId, staffId, startTime);

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        return reservation.Id;
    }
    public async Task CancelReservationAsync(Guid reservationId)
    {
        var reservation = await _context.Reservations
            .FirstOrDefaultAsync(r => r.Id == reservationId);

        if (reservation is null)
            throw new NotFoundException("Reservation not found");

        reservation.Cancel();

        await _context.SaveChangesAsync();
    }
}