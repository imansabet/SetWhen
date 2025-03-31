using MediatR;
using SetWhen.Application.DTOs;

namespace SetWhen.Application.Features.Businesses.Queries;
public record GetMyBusinessesQuery : IRequest<List<BusinessDto>>;
