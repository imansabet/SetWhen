using MediatR;

namespace SetWhen.Application.Features.Businesses.Commands;
public record CreateBusinessCommand(
    string Name,
    string Type,
    string City,
    string Address
) : IRequest<Guid>;