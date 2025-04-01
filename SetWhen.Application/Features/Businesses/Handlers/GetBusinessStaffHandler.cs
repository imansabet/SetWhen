using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Businesses.Queries;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Businesses.Handlers;
public class GetBusinessStaffHandler : IRequestHandler<GetBusinessStaffQuery, List<StaffDto>>
{
    private readonly IBusinessQueryService _queryService;
    private readonly ICurrentUser _currentUser;

    public GetBusinessStaffHandler(IBusinessQueryService queryService, ICurrentUser currentUser)
    {
        _queryService = queryService;
        _currentUser = currentUser;
    }

    public async Task<List<StaffDto>> Handle(GetBusinessStaffQuery request, CancellationToken cancellationToken)
    {
        var ownerId = _currentUser.GetUserId();
        return await _queryService.GetBusinessStaffAsync(request.BusinessId, ownerId, cancellationToken);
    }
}