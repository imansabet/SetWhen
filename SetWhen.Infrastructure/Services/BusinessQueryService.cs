using Microsoft.EntityFrameworkCore;
using SetWhen.Application.DTOs;
using SetWhen.Application.Interfaces;
using SetWhen.Infrastructure.Persistence;

namespace SetWhen.Infrastructure.Services;
public class BusinessQueryService : IBusinessQueryService
{
    private readonly AppDbContext _context;

    public BusinessQueryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<BusinessDto>> GetBusinessesByOwnerAsync(Guid ownerId, CancellationToken cancellationToken)
    {
        return await _context.Businesses
            .Where(b => b.OwnerId == ownerId)
            .Select(b => new BusinessDto(b.Id, b.Name, b.Type, b.City, b.Address))
            .ToListAsync(cancellationToken);
    }

    public async Task<BusinessDashboardDto> GetDashboardAsync(Guid businessId, CancellationToken cancellationToken)
    {
        var totalReservations = await _context.Reservations
                  .CountAsync(r => r.Staff.BusinessId == businessId, cancellationToken);

        var completedReservations = await _context.Reservations
            .CountAsync(r => r.Staff.BusinessId == businessId && r.Status == Domain.Enums.ReservationStatus.Completed, cancellationToken);

        var today = DateTime.Today;
        var todaysReservations = await _context.Reservations
            .CountAsync(r => r.Staff.BusinessId == businessId && r.StartTime.Date == today, cancellationToken);

        var staffCount = await _context.Users
            .CountAsync(u => u.BusinessId == businessId && u.Role == Domain.Entities.UserRole.Staff, cancellationToken);

        return new BusinessDashboardDto(totalReservations, completedReservations, todaysReservations, staffCount);
    }


    public async Task<List<StaffDto>> GetBusinessStaffAsync(Guid businessId, Guid ownerId, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .Include(b => b.Staff)
            .FirstOrDefaultAsync(b => b.Id == businessId && b.OwnerId == ownerId, cancellationToken);

        if (business == null)
            throw new UnauthorizedAccessException("You do not own this business");

        return business.Staff
            .Select(s => new StaffDto(s.Id, s.FullName, s.Email, s.PhoneNumber))
            .ToList();
    }
}