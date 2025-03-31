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
}