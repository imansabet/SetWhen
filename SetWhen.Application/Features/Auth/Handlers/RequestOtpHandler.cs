using MediatR;
using SetWhen.Application.Features.Auth.Commands;
using SetWhen.Application.Interfaces;
using System.Text.RegularExpressions;

namespace SetWhen.Application.Features.Auth.Handlers;
public class RequestOtpHandler : IRequestHandler<RequestOtpCommand>
{
    private readonly IOTPStore _otpStore;

    public RequestOtpHandler(IOTPStore otpStore)
    {
        _otpStore = otpStore;
    }

    public async Task Handle(RequestOtpCommand request, CancellationToken cancellationToken)
    {
        var phone = request.Phone;

        if (string.IsNullOrWhiteSpace(phone) || !Regex.IsMatch(phone, @"^09\d{9}$"))
            throw new ArgumentException("Phone number is invalid");

        var code = GenerateCode();

        await _otpStore.SetCodeAsync(phone, code, TimeSpan.FromMinutes(2));

        Console.WriteLine($"[FAKE SMS] OTP for {phone} = {code}");
    }
    
    private static string GenerateCode()
    {
        var rnd = new Random();
        return rnd.Next(100000, 999999).ToString();
    }
}