using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Services.Commands;
using SetWhen.Application.Interfaces;
using SetWhen.Domain.Entities;
using System;

namespace SetWhen.Application.Features.Services.Handlers;
public class CreateServiceHandler : IRequestHandler<CreateServiceCommand, ServiceDto>
{
    private readonly IServiceManager _serviceManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUser _currentUser;

    public CreateServiceHandler(
        IServiceManager serviceManager,
        IUnitOfWork unitOfWork,
        ICurrentUser currentUser)
    {
        _serviceManager = serviceManager;
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
    }

    public async Task<ServiceDto> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var ownerId = _currentUser.GetUserId();

        var result = await _serviceManager.CreateAsync(
            request.Title,
            request.Duration,
            request.Price,
            ownerId
        );

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result;
    }
}