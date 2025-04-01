using Carter;
using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Services.Commands;
using SetWhen.Application.Features.Services.Queries;

namespace SetWhen.Api.Modules;
public class ServiceModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/services", async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllServicesQuery());
            return Results.Ok(result);
        });

        app.MapPost("/api/services", async (CreateServiceDto dto, ISender sender) =>
        {
            var command = new CreateServiceCommand(dto.Title, dto.Duration, dto.Price);
            var result = await sender.Send(command);
            return Results.Created($"/api/services/{result.Id}", result);
        })
        .RequireAuthorization("StaffOnly");

        app.MapPut("/api/services/{id:guid}", async (Guid id, UpdateServiceCommand command, ISender sender) =>
        {
            if (id != command.Id)
                return Results.BadRequest("ID mismatch");

            var result = await sender.Send(command);
            return Results.Ok(result);
        })
        .RequireAuthorization("StaffOnly");

        app.MapDelete("/api/services/{id:guid}", async (Guid id, ISender sender) =>
        {
            await sender.Send(new DeleteServiceCommand(id));
            return Results.NoContent();
        })
         .RequireAuthorization("StaffOnly");
    }
}