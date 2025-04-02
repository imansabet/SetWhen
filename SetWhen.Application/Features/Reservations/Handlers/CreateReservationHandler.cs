using MediatR;
using SetWhen.Application.Features.Reservations.Commands;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Reservations.Handlers;
public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, Guid>
{
    private readonly IReservationService _reservationService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUser _currentUser;

    public CreateReservationHandler(
        IReservationService reservationService,
        IUnitOfWork unitOfWork,
        ICurrentUser currentUser)
    {
        _reservationService = reservationService;
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
    }

    public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var customerId = _currentUser.GetUserId();

        var reservationId = await _reservationService.CreateReservationAsync(
            customerId,
            request.ServiceId,
            request.StaffId,
            request.StartTime
        );

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return reservationId;
    }
}