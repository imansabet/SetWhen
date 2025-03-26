using Carter;
using MediatR;
using SetWhen.Application.Features.Reservations.Commands;
using SetWhen.Application.Features.Reservations.Queries;

namespace SetWhen.Api.Modules;
public class ReservationModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/reservations", async (CreateReservationCommand command, ISender sender) =>
        {
            var reservationId = await sender.Send(command);
            return Results.Created($"/api/reservations/{reservationId}", new { reservationId });
        });

        app.MapGet("/api/reservations/{userId:guid}", async (Guid userId, ISender sender) =>
        {
            var result = await sender.Send(new GetUserReservationsQuery(userId));
            return Results.Ok(result);
        });
    }
}