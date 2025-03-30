using MediatR;
using SetWhen.Application.DTOs;

namespace SetWhen.Application.Features.Users.Commands;
public record UpdateProfileCommand(string FullName, string Email) : IRequest;
