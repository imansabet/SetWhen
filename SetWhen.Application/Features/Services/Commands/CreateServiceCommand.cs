using MediatR;
using SetWhen.Application.DTOs;

namespace SetWhen.Application.Features.Services.Commands;
public record CreateServiceCommand(CreateServiceDto ServiceData) : IRequest<Guid>;
