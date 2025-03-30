using SetWhen.Domain.Entities;

namespace SetWhen.Infrastructure.Persistence;
public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
       if (!context.Users.Any())
        {
            var customer = User.Create("usertest", "user@example.com", "09120000001", UserRole.Customer);
            var staff = User.Create("stafftest", "staff@example.com", "09120000002", UserRole.Staff);

            context.Users.AddRange(customer, staff);

            if (!context.Services.Any())
            {
                context.Services.AddRange(
                    new Service("consultant 30 min", TimeSpan.FromMinutes(30), 300000, staff.Id),
                    new Service("hair cut", TimeSpan.FromMinutes(15), 150000, staff.Id)
                );
            }
        }

        context.SaveChanges();
    }
}