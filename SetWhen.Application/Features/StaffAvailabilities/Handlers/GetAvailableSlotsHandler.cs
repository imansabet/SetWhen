using MediatR;
using SetWhen.Application.Features.StaffAvailabilities.Queries;
using SetWhen.Application.Interfaces;
using SetWhen.Domain.ValueObjects;

namespace SetWhen.Application.Features.StaffAvailabilities.Handlers;
public class GetAvailableSlotsHandler : IRequestHandler<GetAvailableSlotsQuery, List<TimeRange>>
{
    private readonly IStaffAvailabilityQueryService _queryService;

    public GetAvailableSlotsHandler(IStaffAvailabilityQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<List<TimeRange>> Handle(GetAvailableSlotsQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetAvailableSlotsAsync(request.StaffId, request.Date);
    }
}