using Refit;
using SetWhen.App.DTOs;

namespace SetWhen.App.Api;

[Headers("Authorization : Bearer")]
public interface IAuthApi
{
    [Post("/api/auth/request-code")]
    Task RequestOtpAsync([Body] RequestOtpDto dto);

    [Post("/api/auth/verify")]
    Task<AuthResultDto> VerifyOtpAsync([Body] VerifyOtpDto dto);
}
