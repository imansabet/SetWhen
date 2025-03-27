using MediatR;
using SetWhen.Application.Features.Reservations.Commands;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Reservations.Handlers;
public class CompleteReservationHandler : IRequestHandler<CompleteReservationCommand>
{
    private readonly IReservationService _reservationService;
    private readonly IUnitOfWork _unitOfWork;

    public CompleteReservationHandler(IReservationService reservationService, IUnitOfWork unitOfWork)
    {
        _reservationService = reservationService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CompleteReservationCommand request, CancellationToken cancellationToken)
    {
        await _reservationService.CompleteReservationAsync(request.ReservationId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}