using SetWhen.Application.DTOs;
using SetWhen.Domain.Entities;

namespace SetWhen.Application.Interfaces;
public interface IServiceManager
{
    Task AddAsync(Service service, CancellationToken cancellationToken);
    Task<ServiceDto> UpdateAsync(Guid serviceId, string title, TimeSpan duration, decimal price, Guid userId);
    Task DeleteAsync(Guid serviceId, Guid userId);

}