using SetWhen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetWhen.Application.Interfaces;
public interface IUserService
{
    Task<User> GetOrCreateAsync(string phoneNumber, CancellationToken cancellationToken);
}