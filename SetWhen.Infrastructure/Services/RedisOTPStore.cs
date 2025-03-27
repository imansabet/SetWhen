using SetWhen.Application.Interfaces;
using StackExchange.Redis;

namespace SetWhen.Infrastructure.Services;
public class RedisOTPStore : IOTPStore
{
    private readonly IDatabase _redis;

    public RedisOTPStore(IConnectionMultiplexer connection)
    {
        _redis = connection.GetDatabase();
    }

    public Task SetCodeAsync(string phone, string code, TimeSpan expiresIn)
        => _redis.StringSetAsync(GetKey(phone), code, expiresIn);

    public async Task<string?> GetCodeAsync(string phone)
    {
        var value = await _redis.StringGetAsync(GetKey(phone));
        return value.HasValue ? value.ToString() : null;
    }

    public Task RemoveCodeAsync(string phone)
        => _redis.KeyDeleteAsync(GetKey(phone));

    private static string GetKey(string phone) => $"otp:{phone}";
}