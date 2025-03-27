using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Services.Commands;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Services.Handlers;
public class UpdateServiceHandler : IRequestHandler<UpdateServiceCommand, ServiceDto>
{
    private readonly IServiceManager _serviceManager;

    public UpdateServiceHandler(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<ServiceDto> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        return await _serviceManager.UpdateAsync(request.Id, request.Title, request.Duration, request.Price);
    }
}