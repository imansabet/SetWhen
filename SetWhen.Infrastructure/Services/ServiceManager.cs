using Microsoft.EntityFrameworkCore;
using SetWhen.Application.DTOs;
using SetWhen.Application.Interfaces;
using SetWhen.Domain.Entities;
using SetWhen.Domain.Exceptions;
using SetWhen.Infrastructure.Persistence;

namespace SetWhen.Infrastructure.Services;
public class ServiceManager : IServiceManager
{
    private readonly AppDbContext _context;

    public ServiceManager(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Service service, CancellationToken cancellationToken)
    {
        await _context.Services.AddAsync(service, cancellationToken);
    }

    public async Task<ServiceDto> UpdateAsync(Guid id, string title, TimeSpan duration, decimal price)
    {
        var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);

        if (service is null)
            throw new NotFoundException("Service not found");

        service.Update(title, duration, price);
        await _context.SaveChangesAsync();

        return new ServiceDto(service.Id, service.Title, service.Duration, service.Price);
    }

    public async Task DeleteAsync(Guid id)
    {
        var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);

        if (service is null)
            throw new NotFoundException("Service not found");

        _context.Services.Remove(service);
        await _context.SaveChangesAsync();
    }
}