using MediatR;
using SetWhen.Application.Features.Reservations.Commands;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Reservations.Handlers;
public class ConfirmReservationHandler : IRequestHandler<ConfirmReservationCommand>
{
    private readonly IReservationService _reservationService;
    private readonly IUnitOfWork _unitOfWork;

    public ConfirmReservationHandler(IReservationService reservationService, IUnitOfWork unitOfWork)
    {
        _reservationService = reservationService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(ConfirmReservationCommand request, CancellationToken cancellationToken)
    {
        await _reservationService.ConfirmReservationAsync(request.ReservationId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}