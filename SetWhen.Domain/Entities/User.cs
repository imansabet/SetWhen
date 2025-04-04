﻿namespace SetWhen.Domain.Entities;
public enum UserRole
{
    Admin,
    Staff,
    Customer
}

public class User
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public UserRole Role { get; private set; }
    public Guid? BusinessId { get; private set; }
    protected User() { }

    public static User Create(string fullName, string email, string phoneNumber, UserRole role)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            FullName = fullName,
            Email = email,
            PhoneNumber = phoneNumber,
            Role = role
        };
    }

    public void UpdateProfile(string fullName, string email)
    {
        FullName = fullName;
        Email = email;
    }

    public void AssignToBusiness(Guid businessId)
    {
        BusinessId = businessId;
        Role = UserRole.Staff;
    }
}