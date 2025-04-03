namespace SetWhen.App.Services;
public class TokenStorageService
{
    private const string TokenKey = "auth_token";

    public async Task SaveTokenAsync(string token)
    {
        await SecureStorage.SetAsync(TokenKey, token);
    }

    public async Task<string?> GetTokenAsync()
    {
        var token = await SecureStorage.GetAsync(TokenKey);
        Console.WriteLine($"[TokenStorage] Token = {token}");
        return token;
    }

    public void RemoveToken()
    {
        SecureStorage.Remove(TokenKey);
    }
    public Task LogoutAsync()
    {
        SecureStorage.Remove("auth_token");
        SecureStorage.Remove("user_role");
        return Task.CompletedTask;
    }

    public async Task SaveRoleAsync(string role)
    {
        await SecureStorage.Default.SetAsync("user_role", role);
    }

    public async Task<string?> GetRoleAsync()
    {
        return await SecureStorage.Default.GetAsync("user_role");
    }

    public void RemoveRole()
    {
        SecureStorage.Default.Remove("user_role");
    }
}