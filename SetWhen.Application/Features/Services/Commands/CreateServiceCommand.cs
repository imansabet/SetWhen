using MediatR;
using SetWhen.Application.DTOs;

namespace SetWhen.Application.Features.Services.Commands;
public record CreateServiceCommand(string Title, TimeSpan Duration, decimal Price) : IRequest<ServiceDto>;
