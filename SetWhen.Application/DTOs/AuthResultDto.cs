namespace SetWhen.Application.DTOs;
public record AuthResultDto(Guid UserId, string PhoneNumber, string Role, string Token);
