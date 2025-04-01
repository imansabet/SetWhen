using MediatR;

namespace SetWhen.Application.Features.Businesses.Commands;
public record AddStaffCommand(Guid BusinessId, string FullName, string Email, string PhoneNumber) : IRequest<Guid>;
