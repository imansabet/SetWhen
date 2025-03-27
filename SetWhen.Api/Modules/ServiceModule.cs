using Carter;
using MediatR;
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

        app.MapPost("/api/services", async (CreateServiceCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return Results.Created($"/api/services/{result.Id}", result);
        });

        app.MapPut("/api/services/{id:guid}", async (Guid id, UpdateServiceCommand command, ISender sender) =>
        {
            if (id != command.Id)
                return Results.BadRequest("ID in URL does not match ID in body");

            var result = await sender.Send(command);
            return Results.Ok(result);
        });
    }
}