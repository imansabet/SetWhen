using MediatR;
using SetWhen.Application.Features.Reservations.Commands;
using SetWhen.Application.Interfaces;
using System;

namespace SetWhen.Application.Features.Reservations.Handlers;
public class CancelReservationHandler : IRequestHandler<CancelReservationCommand>
{
    private readonly IReservationService _service;

    public CancelReservationHandler(IReservationService service)
    {
        _service = service;
    }

    public async Task Handle(CancelReservationCommand request, CancellationToken cancellationToken)
    {
        await _service.CancelReservationAsync(request.ReservationId);
    }
}