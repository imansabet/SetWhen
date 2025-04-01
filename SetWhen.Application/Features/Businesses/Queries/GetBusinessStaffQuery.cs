using MediatR;
using SetWhen.Application.DTOs;

namespace SetWhen.Application.Features.Businesses.Queries;
public record GetBusinessStaffQuery(Guid BusinessId) : IRequest<List<StaffDto>>;
