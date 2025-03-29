﻿using Microsoft.EntityFrameworkCore;
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
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber, cancellationToken);

        if (user is null)
        {
            user = User.Create("بدون نام", "", phoneNumber, UserRole.Customer);
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return user;
    }
}