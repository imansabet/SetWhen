namespace SetWhen.Application.Interfaces;
public interface ITokenService
{
    string GenerateToken(Guid userId, string role);
}