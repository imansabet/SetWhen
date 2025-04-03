using SetWhen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetWhen.Application.Interfaces;
public interface IUserService
{
    Task<User> GetOrCreateAsync(string phoneNumber, string role, CancellationToken cancellationToken);
    Task UpdateUserAsync(Guid userId, string fullName, string email, CancellationToken cancellationToken);
    Task<User> GetByIdAsync(Guid userId, CancellationToken cancellationToken);

}