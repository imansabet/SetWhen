using SetWhen.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetWhen.Domain.Entities;
public class StaffAvailability
{
    public Guid StaffId { get; private set; }
    public DayOfWeek Day { get; private set; }
    public TimeRange TimeRange { get; private set; }

    private StaffAvailability() { }

    public StaffAvailability(Guid staffId, DayOfWeek day, TimeRange range)
    {
        StaffId = staffId;
        Day = day;
        TimeRange = range;
    }
}