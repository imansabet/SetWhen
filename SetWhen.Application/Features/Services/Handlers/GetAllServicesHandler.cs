using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Services.Queries;
using System;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Services.Handlers;
public class GetAllServicesHandler : IRequestHandler<GetAllServicesQuery, List<ServiceDto>>
{
    private readonly IServiceQueryService _service;

    public GetAllServicesHandler(IServiceQueryService service)
    {
        _service = service;
    }

    public async Task<List<ServiceDto>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAllServicesAsync();
    }
}