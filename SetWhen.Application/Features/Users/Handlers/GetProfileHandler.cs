using MediatR;
using SetWhen.Application.DTOs;
using SetWhen.Application.Features.Users.Queries;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Users.Handlers;
public class GetProfileHandler : IRequestHandler<GetProfileQuery, UserProfileDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IUserService _userService;

    public GetProfileHandler(ICurrentUser currentUser, IUserService userService)
    {
        _currentUser = currentUser;
        _userService = userService;
    }

    public async Task<UserProfileDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUser.GetUserId();
        var user = await _userService.GetByIdAsync(userId, cancellationToken);

        return new UserProfileDto(user.FullName, user.Email, user.PhoneNumber, user.Role.ToString());
    }
}