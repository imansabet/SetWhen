using SetWhen.Application.DTOs;

namespace SetWhen.Application.Interfaces;
public interface IServiceQueryService
{
    Task<List<ServiceDto>> GetAllServicesAsync();
    Task<List<ServiceDto>> GetServicesByOwnerAsync(Guid ownerId);

}