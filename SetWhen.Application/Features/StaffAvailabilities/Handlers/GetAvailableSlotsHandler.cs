using MediatR;
using SetWhen.Application.Features.StaffAvailabilities.Queries;
using SetWhen.Application.Interfaces;
using SetWhen.Domain.ValueObjects;

namespace SetWhen.Application.Features.StaffAvailabilities.Handlers;
public class GetAvailableSlotsHandler : IRequestHandler<GetAvailableSlotsQuery, List<TimeRange>>
{
    private readonly IStaffAvailabilityQueryService _queryService;
    private readonly IServiceLookupService _serviceLookupService;

    public GetAvailableSlotsHandler(
        IStaffAvailabilityQueryService queryService,
        IServiceLookupService serviceLookupService)
    {
        _queryService = queryService;
        _serviceLookupService = serviceLookupService;
    }

    public async Task<List<TimeRange>> Handle(GetAvailableSlotsQuery request, CancellationToken cancellationToken)
    {
        TimeSpan? duration = null;

        if (request.ServiceId.HasValue)
        {
            duration = await _serviceLookupService.GetServiceDurationAsync(request.ServiceId.Value);
        }

        return await _queryService.GetAvailableSlotsAsync(
            request.StaffId,
            request.Date,
            duration
        );
    }
}