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

    public CreateServiceHandler(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<ServiceDto> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        return await _serviceManager.CreateAsync(request.Title, request.Duration, request.Price);
    }
}