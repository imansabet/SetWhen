
using MediatR;
using SetWhen.Application.Features.Services.Commands;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Services.Handlers;
public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand>
{
    private readonly IServiceManager _serviceManager;
    private readonly ICurrentUser _currentUser;

    public DeleteServiceHandler(IServiceManager serviceManager, ICurrentUser currentUser)
    {
        _serviceManager = serviceManager;
        _currentUser = currentUser;
    }

    public async Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        await _serviceManager.DeleteAsync(request.Id, _currentUser.GetUserId());
    }
}