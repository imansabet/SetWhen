using MediatR;
using SetWhen.Application.DTOs;

namespace SetWhen.Application.Features.Users.Commands;
public record UpdateUserProfileCommand(Guid UserId, UpdateUserDto Data) : IRequest;
