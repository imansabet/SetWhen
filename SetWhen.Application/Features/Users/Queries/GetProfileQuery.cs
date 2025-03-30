using MediatR;
using SetWhen.Application.DTOs;

namespace SetWhen.Application.Features.Users.Queries;
public record GetProfileQuery : IRequest<UserProfileDto>;
