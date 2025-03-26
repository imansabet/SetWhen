using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Reservations.Queries;
using SetWhen.Application.Interfaces;
using System;

namespace SetWhen.Application.Features.Reservations.Handlers;
public class GetUserReservationsHandler : IRequestHandler<GetUserReservationsQuery, List<ReservationDto>>
{
    private readonly IReservationQueryService _queryService;

    public GetUserReservationsHandler(IReservationQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<List<ReservationDto>> Handle(GetUserReservationsQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetReservationsForUserAsync(request.UserId);
    }
}