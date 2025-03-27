namespace SetWhen.Application.DTOs;

public record ReservationDto(
  Guid Id,
  string ServiceTitle,
  string StaffName,
  DateTime StartTime,
  string Status

);
