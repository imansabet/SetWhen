using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetWhen.Application.Interfaces;
public interface IServiceLookupService
{
    Task<TimeSpan?> GetServiceDurationAsync(Guid serviceId);
}