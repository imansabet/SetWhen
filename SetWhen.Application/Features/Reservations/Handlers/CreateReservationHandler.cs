using MediatR;
using SetWhen.Application.Features.Reservations.Commands;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Reservations.Handlers;
public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, Guid>
{
    private readonly IReservationService _reservationService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReservationHandler(IReservationService reservationService, IUnitOfWork unitOfWork)
    {
        _reservationService = reservationService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservationId = await _reservationService.CreateReservationAsync(
            request.CustomerId,
            request.ServiceId,
            request.StaffId,
            request.StartTime
        );

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return reservationId;
    }
}