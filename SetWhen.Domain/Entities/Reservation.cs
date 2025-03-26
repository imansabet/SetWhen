using SetWhen.Domain.Enums;
using SetWhen.Domain.Exceptions;

namespace SetWhen.Domain.Entities;
public class Reservation
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid ServiceId { get; private set; }
    public Guid StaffId { get; private set; }
    public DateTime StartTime { get; private set; }
    public ReservationStatus Status { get; private set; }

    private Reservation() { }

    public Reservation(Guid customerId, Guid serviceId, Guid staffId, DateTime startTime)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        ServiceId = serviceId;
        StaffId = staffId;
        StartTime = startTime;
        Status = ReservationStatus.Pending;
    }

    public void Cancel()
    {
        if (Status == ReservationStatus.Completed)
            throw new BusinessRuleException("Completed reservations cannot be canceled.");

        Status = ReservationStatus.Canceled;
    }

    public void Confirm()
    {
        if (Status != ReservationStatus.Pending)
            throw new BusinessRuleException("Only pending reservations can be confirmed.");

        Status = ReservationStatus.Confirmed;
    }

    public void Complete()
    {
        if (Status != ReservationStatus.Confirmed)
            throw new BusinessRuleException("Only confirmed reservations can be completed.");

        Status = ReservationStatus.Completed;
    }
}