using MediatR;

namespace SetWhen.Application.Features.Auth.Commands;
public record RequestOtpCommand(string Phone) : IRequest;
