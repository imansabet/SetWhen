using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Services.Queries;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Services.Handlers;
public class GetMyServicesHandler : IRequestHandler<GetMyServicesQuery, List<ServiceDto>>
{
    private readonly IServiceQueryService _queryService;
    private readonly ICurrentUser _currentUser;

    public GetMyServicesHandler(IServiceQueryService queryService, ICurrentUser currentUser)
    {
        _queryService = queryService;
        _currentUser = currentUser;
    }

    public async Task<List<ServiceDto>> Handle(GetMyServicesQuery request, CancellationToken cancellationToken)
    {
        var ownerId = _currentUser.GetUserId();
        return await _queryService.GetServicesByOwnerAsync(ownerId);
    }
}