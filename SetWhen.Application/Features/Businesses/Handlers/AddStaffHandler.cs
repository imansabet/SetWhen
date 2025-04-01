using MediatR;
using SetWhen.Application.Features.Businesses.Commands;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Businesses.Handlers;
public class AddStaffHandler : IRequestHandler<AddStaffCommand, Guid>
{
    private readonly IBusinessService _businessService;
    private readonly ICurrentUser _currentUser;

    public AddStaffHandler(IBusinessService businessService, ICurrentUser currentUser)
    {
        _businessService = businessService;
        _currentUser = currentUser;
    }

    public async Task<Guid> Handle(AddStaffCommand request, CancellationToken cancellationToken)
    {
        var ownerId = _currentUser.GetUserId();
        return await _businessService.AddStaffToBusinessAsync(
            request.BusinessId,
            request.FullName,
            request.Email,
            request.PhoneNumber,
            ownerId,
            cancellationToken
        );
    }
}