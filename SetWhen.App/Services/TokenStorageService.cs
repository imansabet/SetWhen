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
        return await SecureStorage.GetAsync(TokenKey);
    }

    public void RemoveToken()
    {
        SecureStorage.Remove(TokenKey);
    }
}