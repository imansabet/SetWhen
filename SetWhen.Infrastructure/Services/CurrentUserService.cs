using Microsoft.AspNetCore.Http;
using SetWhen.Application.Interfaces;
using System.Security.Claims;

namespace SetWhen.Infrastructure.Services;
public class CurrentUserService : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetUserId()
    {
        var userIdStr = _httpContextAccessor.HttpContext?.User
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdStr is null || !Guid.TryParse(userIdStr, out var userId))
            throw new UnauthorizedAccessException("User ID not found in token.");

        return userId;
    }

    public string? GetRole()
    {
        return _httpContextAccessor.HttpContext?.User
            .FindFirst(ClaimTypes.Role)?.Value;
    }
}
