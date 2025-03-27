using SetWhen.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetWhen.Domain.Entities;
public class StaffAvailability
{
    public Guid Id { get; private set; }
    public Guid StaffId { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    public TimeRange TimeRange { get; private set; }

    private StaffAvailability() { }

    public StaffAvailability(Guid staffId, DayOfWeek dayOfWeek , TimeRange range)
    {
        Id = Guid.NewGuid();
        StaffId = staffId;
        DayOfWeek = dayOfWeek;
        TimeRange = range;
    }
}