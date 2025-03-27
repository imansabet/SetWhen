using Microsoft.EntityFrameworkCore;
using SetWhen.Application.Interfaces;
using SetWhen.Domain.Entities;
using SetWhen.Domain.Exceptions;
using SetWhen.Infrastructure.Persistence;

namespace SetWhen.Infrastructure.Services;
public class ReservationService : IReservationService
{
    private readonly AppDbContext _context;

    public ReservationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Reservation> CreateReservationAsync(Guid customerId, Guid serviceId, Guid staffId, DateTime startTime)
    {
        var reservation = new Reservation(customerId, serviceId, staffId, startTime);
        await _context.Reservations.AddAsync(reservation);
        return reservation;
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