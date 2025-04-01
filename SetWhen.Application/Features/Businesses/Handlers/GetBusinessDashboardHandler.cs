using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Businesses.Queries;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Businesses.Handlers;
public class GetBusinessDashboardHandler : IRequestHandler<GetBusinessDashboardQuery, BusinessDashboardDto>
{
    private readonly IBusinessQueryService _businessQueryService;

    public GetBusinessDashboardHandler(IBusinessQueryService businessQueryService)
    {
        _businessQueryService = businessQueryService;
    }

    public async Task<BusinessDashboardDto> Handle(GetBusinessDashboardQuery request, CancellationToken cancellationToken)
    {
        return await _businessQueryService.GetDashboardAsync(request.BusinessId, cancellationToken);
    }
}