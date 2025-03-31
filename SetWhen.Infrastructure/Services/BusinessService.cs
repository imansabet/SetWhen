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
}