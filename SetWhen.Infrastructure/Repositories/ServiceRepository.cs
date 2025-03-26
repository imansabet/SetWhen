using Microsoft.EntityFrameworkCore;
using SetWhen.Application.DTOs;
using SetWhen.Application.Interfaces;
using SetWhen.Infrastructure.Persistence;

namespace SetWhen.Infrastructure.Repositories;
public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _context;

    public ServiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ServiceDto>> GetAllServicesAsync()
    {
        return await _context.Services
            .Select(s => new ServiceDto(s.Id, s.Title, s.Duration, s.Price))
            .ToListAsync();
    }
}