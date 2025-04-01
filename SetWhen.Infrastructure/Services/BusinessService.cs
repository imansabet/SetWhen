using Microsoft.EntityFrameworkCore;
using SetWhen.Application.Interfaces;
using SetWhen.Domain.Entities;
using SetWhen.Infrastructure.Persistence;

namespace SetWhen.Infrastructure.Services;
public class BusinessService : IBusinessService
{
    private readonly AppDbContext _context;

    public BusinessService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateBusinessAsync(string name, string type, string city, string address, Guid ownerId, CancellationToken cancellationToken)
    {
        var business = new Business(name, type, city, address, ownerId);
        _context.Businesses.Add(business);
        await _context.SaveChangesAsync(cancellationToken);
        return business.Id;
    }
    public async Task<Guid> AddStaffToBusinessAsync(Guid businessId, string fullName, string email, string phoneNumber, Guid ownerId, CancellationToken cancellationToken)
    {
        var business = await _context.Businesses
            .FirstOrDefaultAsync(b => b.Id == businessId && b.OwnerId == ownerId, cancellationToken);

        if (business is null)
            throw new UnauthorizedAccessException("You are not the owner of this business.");

        var staff = await _context.Users
            .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber, cancellationToken);

        if (staff is null)
        {
            staff = User.Create(fullName, email, phoneNumber, UserRole.Staff);
            staff.AssignToBusiness(businessId);
            _context.Users.Add(staff);
        }
        else
        {
            staff.UpdateProfile(fullName, email);
            staff.AssignToBusiness(businessId);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return staff.Id; 
    }
}