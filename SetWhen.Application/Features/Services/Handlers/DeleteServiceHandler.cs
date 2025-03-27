
using MediatR;
using SetWhen.Application.Features.Services.Commands;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Services.Handlers;
public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand>
{
    private readonly IServiceManager _serviceManager;

    public DeleteServiceHandler(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        await _serviceManager.DeleteAsync(request.Id);
    }
}