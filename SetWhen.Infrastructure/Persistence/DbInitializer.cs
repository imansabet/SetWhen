using SetWhen.Domain.Entities;

namespace SetWhen.Infrastructure.Persistence;
public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new User("usertest", "user@example.com", "09120000001", UserRole.Customer),
                new User("stafftest", "staff@example.com", "09120000002", UserRole.Staff)
            );
        }

        if (!context.Services.Any())
        {
            context.Services.AddRange(
                new Service("consultant 30 min ", TimeSpan.FromMinutes(30), 300000),
                new Service("hair cut", TimeSpan.FromMinutes(15), 150000)
            );
        }

        context.SaveChanges();
    }
}