using Carter;
using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Users.Commands;
using System.Security.Claims;

namespace SetWhen.Api.Modules;

public class UserModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/users/me", async (HttpContext context, UpdateUserDto dto, ISender sender) =>
        {
            var userIdStr = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(userIdStr, out var userId)) return Results.Unauthorized();

            await sender.Send(new UpdateUserProfileCommand(userId, dto));
            return Results.NoContent();
        })
        .RequireAuthorization();
    }
}
