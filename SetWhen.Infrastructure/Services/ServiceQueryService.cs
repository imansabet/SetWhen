using Microsoft.EntityFrameworkCore;
using SetWhen.Application.DTOs;
using SetWhen.Application.Interfaces;
using SetWhen.Infrastructure.Persistence;

namespace SetWhen.Infrastructure.Services;
public class ServiceQueryService : IServiceQueryService
{
    private readonly AppDbContext _context;

    public ServiceQueryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ServiceDto>> GetAllServicesAsync()
    {
        return await _context.Services
            .Select(s => new ServiceDto(
                s.Id,
                s.Title,
                s.Duration,
                s.Price
            )).ToListAsync();
    }

    public async Task<List<ServiceDto>> GetServicesByOwnerAsync(Guid ownerId)
    {
        return await _context.Services
            .Where(s => s.OwnerId == ownerId)
            .Select(s => new ServiceDto(s.Id, s.Title, s.Duration, s.Price))
            .ToListAsync();
    }
}