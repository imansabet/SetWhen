using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Auth.Commands;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Auth.Handlers;
public class VerifyOtpHandler : IRequestHandler<VerifyOtpCommand, AuthResultDto>
{
    private readonly IOTPStore _otpStore;
    private readonly IUserService _userService;

    public VerifyOtpHandler(IOTPStore otpStore, IUserService userService)
    {
        _otpStore = otpStore;
        _userService = userService;
    }

    public async Task<AuthResultDto> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
    {
        var storedCode = await _otpStore.GetCodeAsync(request.Phone);

        if (storedCode != request.Code)
            throw new UnauthorizedAccessException("Invalid or expired OTP");

        await _otpStore.RemoveCodeAsync(request.Phone);

        var user = await _userService.GetOrCreateAsync(request.Phone, cancellationToken);

        return new AuthResultDto(user.Id, user.PhoneNumber, user.Role.ToString());
    }
}