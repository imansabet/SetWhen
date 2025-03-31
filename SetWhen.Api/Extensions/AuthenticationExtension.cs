using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SetWhen.Api.Extensions;
public static class AuthenticationExtension
{
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config)
    {
        var jwtKey = config["Jwt:Key"] ?? "verylong_secure_secret_key_here_12345678!";
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("StaffOnly", policy => policy.RequireRole("Staff"));
            options.AddPolicy("CustomerOnly", policy => policy.RequireRole("Customer"));
        });

        return services;
    }
}