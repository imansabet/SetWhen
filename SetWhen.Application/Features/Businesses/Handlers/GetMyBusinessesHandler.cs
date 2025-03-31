using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Businesses.Queries;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Businesses.Handlers;
public class GetMyBusinessesHandler : IRequestHandler<GetMyBusinessesQuery, List<BusinessDto>>
{
    private readonly IBusinessQueryService _queryService;
    private readonly ICurrentUser _currentUser;

    public GetMyBusinessesHandler(IBusinessQueryService queryService, ICurrentUser currentUser)
    {
        _queryService = queryService;
        _currentUser = currentUser;
    }

    public async Task<List<BusinessDto>> Handle(GetMyBusinessesQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUser.GetUserId();
        return await _queryService.GetBusinessesByOwnerAsync(userId, cancellationToken);
    }
}