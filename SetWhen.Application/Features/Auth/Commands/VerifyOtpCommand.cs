using MediatR;
using SetWhen.Application.DTOs;

namespace SetWhen.Application.Features.Auth.Commands;
public record VerifyOtpCommand(string Phone, string Code) : IRequest<AuthResultDto>;
