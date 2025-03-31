using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using SetWhen.Infrastructure.Persistence;
using SetWhen.Application.Interfaces;
using SetWhen.Infrastructure.Services;

namespace SetWhen.Infrastructure.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IReservationQueryService, ReservationQueryService>();
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<IStaffAvailabilityService, StaffAvailabilityService>();
        services.AddScoped<IStaffAvailabilityQueryService, StaffAvailabilityQueryService>();
        services.AddScoped<IServiceLookupService, ServiceLookupService>();
        services.AddScoped<IServiceQueryService, ServiceQueryService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICurrentUser, CurrentUserService>();
        services.AddScoped<IOTPStore, RedisOTPStore>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBusinessService, BusinessService>();
        services.AddScoped<IBusinessQueryService, BusinessQueryService>();

        services.AddSingleton<IConnectionMultiplexer>(
            ConnectionMultiplexer.Connect("localhost"));

        return services;
    }
}
