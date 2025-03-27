using MediatR;
using SetWhen.Application.Features.StaffAvailabilities.Commands;
using SetWhen.Application.Interfaces;
using SetWhen.Domain.Entities;
using SetWhen.Domain.ValueObjects;
using System;

namespace SetWhen.Application.Features.StaffAvailabilities.Handlers;
public class CreateStaffAvailabilityHandler : IRequestHandler<CreateStaffAvailabilityCommand>
{
    private readonly IStaffAvailabilityService _service;

    public CreateStaffAvailabilityHandler(IStaffAvailabilityService service)
    {
        _service = service;
    }

    public async Task Handle(CreateStaffAvailabilityCommand request, CancellationToken cancellationToken)
    {
        var range = new TimeRange(request.Start, request.End);

        await _service.CreateAsync(request.StaffId, request.DayOfWeek, range);
    }
}