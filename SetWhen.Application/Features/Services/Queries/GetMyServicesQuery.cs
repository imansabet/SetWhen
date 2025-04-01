using MediatR;
using SetWhen.Application.DTOs;

namespace SetWhen.Application.Features.Services.Queries;
public record GetMyServicesQuery : IRequest<List<ServiceDto>>;
