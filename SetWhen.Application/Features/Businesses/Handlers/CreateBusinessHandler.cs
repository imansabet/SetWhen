using MediatR;
using SetWhen.Application.Features.Businesses.Commands;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Businesses.Handlers;
public class CreateBusinessHandler : IRequestHandler<CreateBusinessCommand, Guid>
{
    private readonly IBusinessService _businessService;
    private readonly ICurrentUser _currentUser;

    public CreateBusinessHandler(IBusinessService businessService, ICurrentUser currentUser)
    {
        _businessService = businessService;
        _currentUser = currentUser;
    }

    public async Task<Guid> Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
    {
        var ownerId = _currentUser.GetUserId();

        return await _businessService.CreateBusinessAsync(
            request.Name,
            request.Type,
            request.City,
            request.Address,
            ownerId,
            cancellationToken);
    }
}