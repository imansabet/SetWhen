namespace SetWhen.Application.DTOs;
public record BusinessDashboardDto(
    int TotalReservations,
    int CompletedReservations,
    int TodaysReservations,
    int StaffCount
);
