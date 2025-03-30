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

    public CreateServiceHandler(IServiceManager serviceManager, IUnitOfWork unitOfWork)
    {
        _serviceManager = serviceManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var dto = request.ServiceData;

        var service = new Service(dto.Title, dto.Duration, dto.Price);

        await _serviceManager.AddAsync(service, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return service.Id;
    }
}