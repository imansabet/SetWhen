using SetWhen.Application.DTOs;

namespace SetWhen.Application.Interfaces;
public interface IServiceManager
{
    Task<ServiceDto> CreateAsync(string title, TimeSpan duration, decimal price);
    Task<ServiceDto> UpdateAsync(Guid id, string title, TimeSpan duration, decimal price);

}