using MediatR;
using SetWhen.Application.DTOs;

namespace SetWhen.Application.Features.Services.Queries;
public record GetAllServicesQuery : IRequest<List<ServiceDto>>;
