using SetWhen.Application.DTOs;
using SetWhen.Domain.Entities;

namespace SetWhen.Application.Interfaces;
public interface IServiceManager
{
    Task AddAsync(Service service, CancellationToken cancellationToken);
    Task<ServiceDto> UpdateAsync(Guid id, string title, TimeSpan duration, decimal price);
    Task DeleteAsync(Guid id);


}