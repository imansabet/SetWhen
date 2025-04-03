using System.Net.Http.Headers;

namespace SetWhen.App.Services;
public class TokenAuthHandler : DelegatingHandler
{
    private readonly TokenStorageService _tokenStorage;

    public TokenAuthHandler(TokenStorageService tokenStorage)
    {
        _tokenStorage = tokenStorage;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _tokenStorage.GetTokenAsync();
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            Console.WriteLine($"[RefitHandler] Using Token: {token}");
        }

        return await base.SendAsync(request, cancellationToken);
    }
}