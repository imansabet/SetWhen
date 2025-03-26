using SetWhen.Application.DTOs;

namespace SetWhen.Application.Interfaces;
public interface IServiceRepository
{
    Task<List<ServiceDto>> GetAllServicesAsync();
}