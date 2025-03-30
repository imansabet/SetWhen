using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Services.Commands;
using SetWhen.Application.Interfaces;
using SetWhen.Domain.Exceptions;
using System;

namespace SetWhen.Application.Features.Services.Handlers;
public class UpdateServiceHandler : IRequestHandler<UpdateServiceCommand, ServiceDto>
{
    private readonly IServiceManager _serviceManager;
    private readonly ICurrentUser _currentUser;

    public UpdateServiceHandler(IServiceManager serviceManager, ICurrentUser currentUser)
    {
        _serviceManager = serviceManager;
        _currentUser = currentUser;
    }

    public async Task<ServiceDto> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        return await _serviceManager.UpdateAsync(
            request.Id,
            request.Title,
            request.Duration,
            request.Price,
            _currentUser.GetUserId()
        );
    }
}