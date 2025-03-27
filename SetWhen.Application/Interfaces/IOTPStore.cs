namespace SetWhen.Application.Interfaces;
public interface IOTPStore
{
    Task SetCodeAsync(string phone, string code, TimeSpan expiresIn);
    Task<string?> GetCodeAsync(string phone);
    Task RemoveCodeAsync(string phone);
}