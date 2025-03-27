using Microsoft.EntityFrameworkCore;
using SetWhen.Application.Interfaces;
using SetWhen.Infrastructure.Persistence;

namespace SetWhen.Infrastructure.Services;
public class ServiceLookupService : IServiceLookupService
{
    private readonly AppDbContext _context;

    public ServiceLookupService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TimeSpan?> GetServiceDurationAsync(Guid serviceId)
    {
        var service = await _context.Services
            .Where(s => s.Id == serviceId)
            .Select(s => s.Duration)
            .FirstOrDefaultAsync();

        return service == default ? null : service;
    }
}