using SetWhen.Application.DTOs;

namespace SetWhen.Application.Interfaces;
public interface IBusinessQueryService
{
    Task<List<BusinessDto>> GetBusinessesByOwnerAsync(Guid ownerId, CancellationToken cancellationToken);
}