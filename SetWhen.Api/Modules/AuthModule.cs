using Carter;
using MediatR;
using SetWhen.Application.Features.Auth.Commands;

namespace SetWhen.Api.Modules;
public class AuthModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/request-code", async (RequestOtpCommand command, ISender sender) =>
        {
            await sender.Send(command);
            return Results.Ok(new { message = "OTP sent (check console)" });
        });
    }
}