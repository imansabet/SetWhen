using MediatR;

namespace SetWhen.Application.Features.Services.Commands;
public record DeleteServiceCommand(Guid Id) : IRequest;
