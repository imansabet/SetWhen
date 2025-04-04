namespace SetWhen.App.Services;
public class AuthStateService
{
    private readonly TokenStorageService _tokenStorage;

    public bool IsLoggedIn { get; private set; } = false;
    public string? Role { get; private set; }

    public event Action? OnAuthStateChanged;

    public AuthStateService(TokenStorageService tokenStorage)
    {
        _tokenStorage = tokenStorage;
    }

    public async Task InitializeAsync()
    {
        var token = await _tokenStorage.GetTokenAsync();
        var role = await _tokenStorage.GetRoleAsync();

        IsLoggedIn = !string.IsNullOrWhiteSpace(token);
        Role = role;

        OnAuthStateChanged?.Invoke();
    }

    public async Task LoginAsync(string token, string role)
    {
        await _tokenStorage.SaveTokenAsync(token);
        await _tokenStorage.SaveRoleAsync(role);

        IsLoggedIn = true;
        Role = role;

        OnAuthStateChanged?.Invoke();
    }

    public async Task LogoutAsync()
    {
        await _tokenStorage.LogoutAsync();

        IsLoggedIn = false;
        Role = null;

        OnAuthStateChanged?.Invoke();
    }
}