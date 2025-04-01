using SetWhen.Application.DTOs;
using SetWhen.Domain.Entities;

namespace SetWhen.Application.Interfaces;
public interface IServiceManager
{
    Task<ServiceDto> CreateAsync(string title, TimeSpan duration, decimal price, Guid ownerId);
    Task<ServiceDto> UpdateAsync(Guid serviceId, string title, TimeSpan duration, decimal price, Guid userId);
    Task DeleteAsync(Guid serviceId, Guid userId);

}