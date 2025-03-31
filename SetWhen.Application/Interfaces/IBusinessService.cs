namespace SetWhen.Application.Interfaces;
public interface IBusinessService
{
    Task<Guid> CreateBusinessAsync(string name, string type, string city, string address, Guid ownerId, CancellationToken cancellationToken);
}