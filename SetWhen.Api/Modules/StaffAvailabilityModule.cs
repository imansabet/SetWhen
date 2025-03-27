using Carter;
using MediatR;
using SetWhen.Application.Features.StaffAvailabilities.Commands;

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
    }
}
