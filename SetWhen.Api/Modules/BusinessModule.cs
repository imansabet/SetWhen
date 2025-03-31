using Carter;
using MediatR;
using SetWhen.Application.Features.Businesses.Commands;
using SetWhen.Application.Features.Businesses.Queries;

namespace SetWhen.Api.Modules;

public class BusinessModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/businesses", async (CreateBusinessCommand command, ISender sender) =>
        {
            var id = await sender.Send(command);
            return Results.Created($"/api/businesses/{id}", new { id });
        })
            .RequireAuthorization();

        app.MapGet("/api/businesses/my", async (ISender sender) =>
        {
            var result = await sender.Send(new GetMyBusinessesQuery());
            return Results.Ok(result);
        })
          .RequireAuthorization();

    }
}
