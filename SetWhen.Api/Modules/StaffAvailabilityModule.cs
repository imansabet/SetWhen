using Carter;
using MediatR;
using SetWhen.Application.Features.StaffAvailabilities.Commands;
using SetWhen.Application.Features.StaffAvailabilities.Queries;
using System.Security.Claims;

namespace SetWhen.Api.Modules;

public class StaffAvailabilityModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/staff-availabilities", async (
            HttpContext context,
            CreateStaffAvailabilityCommand command,
            ISender sender) =>
        {
            var staffIdStr = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!Guid.TryParse(staffIdStr, out var staffId))
                return Results.Unauthorized();

            var cmd = command with { StaffId = staffId };

            await sender.Send(cmd);
            return Results.NoContent();
        })
        .RequireAuthorization("StaffOnly");

        app.MapGet("/api/staff-availability/slots", async (
            [AsParameters] GetAvailableSlotsQuery query,
            ISender sender) =>
        {
            var result = await sender.Send(query);
            return Results.Ok(result);
        });

    }
}
