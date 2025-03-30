using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Services.Commands;
using SetWhen.Application.Interfaces;
using SetWhen.Domain.Entities;
using System;

namespace SetWhen.Application.Features.Services.Handlers;
public class CreateServiceHandler : IRequestHandler<CreateServiceCommand, Guid>
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

    public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var dto = request.ServiceData;

        var userId = _currentUser.GetUserId();

        var service = new Service(
            dto.Title,
            dto.Duration,
            dto.Price,
            userId 
        );

        await _serviceManager.AddAsync(service, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return service.Id;
    }
}