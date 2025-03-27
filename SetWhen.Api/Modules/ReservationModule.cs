﻿using Carter;
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