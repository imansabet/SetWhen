using Microsoft.EntityFrameworkCore;
using SetWhen.Application.Interfaces;
using SetWhen.Domain.Entities;
using SetWhen.Infrastructure.Persistence;

namespace SetWhen.Infrastructure.Services;
public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetOrCreateAsync(string phoneNumber, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[UserService] 🔍 Checking user by phone: {phoneNumber}");

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber, cancellationToken);

        if (user is null)
        {
            Console.WriteLine($"[UserService] ❌ No user found. Creating new one...");

            user = User.Create("بدون نام", "", phoneNumber, UserRole.Customer);
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            Console.WriteLine($"[UserService] ✅ New user created with ID: {user.Id}");
        }
        else
        {
            Console.WriteLine($"[UserService] ✅ User already exists with ID: {user.Id}");
        }

        return user;
    }


    public async Task UpdateUserAsync(Guid userId, string fullName, string email, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(new object[] { userId }, cancellationToken);

        if (user == null)
        {
            Console.WriteLine($"[DEBUG] User with ID {userId} not found in DB!");
            throw new Exception("User not found");
        }

        user.UpdateProfile(fullName, email);
        await _context.SaveChangesAsync(cancellationToken);
    }


    public async Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync([userId], cancellationToken);
        if (user is null) throw new Exception("User not found");
        return user;
    }
}