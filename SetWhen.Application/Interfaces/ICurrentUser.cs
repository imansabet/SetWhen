namespace SetWhen.Application.Interfaces;
public interface ICurrentUser
{
    Guid GetUserId();
    string? GetRole();
}