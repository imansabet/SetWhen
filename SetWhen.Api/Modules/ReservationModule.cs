using Azure.Core;
using Azure;
using Carter;
using Humanizer;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SetWhen.Application.Features.Reservations.Commands;
using SetWhen.Application.Features.Reservations.Queries;
using System.Collections.Generic;
using System.Security.Claims;

namespace SetWhen.Api.Modules;
public class ReservationModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/reservations", async (CreateReservationCommand command, ISender sender) =>
        {
            var reservationId = await sender.Send(command);
            return Results.Created($"/api/reservations/{reservationId}", new { reservationId });
        })
            .RequireAuthorization("CustomerOnly");

        //  Request with JWT Token
        //      |
        //  [HttpContext.User] → extract userId from claim
        //      |
        //  [JWT valid] → send userId to MediatR → get reservations
        //      |
        //  [Response] → 200 OK + list of reservations

        app.MapGet("/api/reservations", async (HttpContext context, ISender sender) =>
        {
            var userIdStr = context.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (!Guid.TryParse(userIdStr, out var userId))
                return Results.Unauthorized();

            var result = await sender.Send(new GetUserReservationsQuery(userId));
            return Results.Ok(result);
        })
            .RequireAuthorization();


        app.MapPut("/api/reservations/{id:guid}/cancel", async (Guid id, ISender sender) =>
        {
            await sender.Send(new CancelReservationCommand(id));
            return Results.NoContent();
        });


        app.MapPut("/api/reservations/{id:guid}/confirm", async (Guid id, ISender sender) =>
        {
            await sender.Send(new ConfirmReservationCommand(id));
            return Results.NoContent();
        });

        app.MapPut("/api/reservations/{id:guid}/complete", async (Guid id, ISender sender) =>
        {
            await sender.Send(new CompleteReservationCommand(id));
            return Results.NoContent();
        });
    }
}