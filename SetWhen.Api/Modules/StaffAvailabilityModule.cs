using Carter;
using MediatR;
using SetWhen.Application.Features.StaffAvailabilities.Commands;
using SetWhen.Application.Features.StaffAvailabilities.Queries;

namespace SetWhen.Api.Modules;

public class StaffAvailabilityModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/staff-availability", async (CreateStaffAvailabilityCommand command, ISender sender) =>
        {
            await sender.Send(command);
            return Results.StatusCode(201);
        });

        app.MapGet("/api/staff-availability/slots", async (
            [AsParameters] GetAvailableSlotsQuery query,
            ISender sender) =>
        {
            var result = await sender.Send(query);
            return Results.Ok(result);
        });

    }
}
