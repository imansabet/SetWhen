using Carter;
using MediatR;
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
    }
}