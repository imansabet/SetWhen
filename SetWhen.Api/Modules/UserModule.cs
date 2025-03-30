using Carter;
using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Users.Commands;
using SetWhen.Application.Features.Users.Queries;
using System.Security.Claims;

namespace SetWhen.Api.Modules;

public class UserModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
       
        app.MapPut("/api/users/profile", async (UpdateProfileCommand command, ISender sender) =>
        {
            await sender.Send(command);
            return Results.NoContent();
        })
        .RequireAuthorization();


        app.MapGet("/api/users/profile", async (ISender sender) =>
        {
            var profile = await sender.Send(new GetProfileQuery());
            return Results.Ok(profile);
        })
        .RequireAuthorization();
    }
}
