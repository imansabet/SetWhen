using Microsoft.EntityFrameworkCore;
using SetWhen.Application.DTOs;
using SetWhen.Application.Interfaces;
using SetWhen.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetWhen.Infrastructure.Services;
public class ReservationQueryService : IReservationQueryService
{
    private readonly AppDbContext _context;

    public ReservationQueryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ReservationDto>> GetReservationsForUserAsync(Guid userId)
    {
        return await _context.Reservations
            .Include(r => r.Service)
            .Include(r => r.Staff)
            .Where(r => r.CustomerId == userId)
            .Select(r => new ReservationDto(
                r.Id,
                r.Service.Title,
                r.Staff.FullName,
                r.StartTime
            ))
            .ToListAsync();
    }
}