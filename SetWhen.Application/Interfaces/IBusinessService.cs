namespace SetWhen.Application.Interfaces;
public interface IBusinessService
{
    Task<Guid> CreateBusinessAsync(string name, string type, string city, string address, Guid ownerId, CancellationToken cancellationToken);
    Task<Guid> AddStaffToBusinessAsync(Guid businessId, string fullName, string email, string phoneNumber, Guid ownerId, CancellationToken cancellationToken);

}