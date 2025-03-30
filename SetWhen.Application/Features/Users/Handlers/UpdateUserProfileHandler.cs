using MediatR;
using SetWhen.Application.Features.Users.Commands;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Users.Handlers;
public class UpdateProfileHandler : IRequestHandler<UpdateProfileCommand>
{
    private readonly IUserService _userService;
    private readonly ICurrentUser _currentUser;

    public UpdateProfileHandler(IUserService userService, ICurrentUser currentUser)
    {
        _userService = userService;
        _currentUser = currentUser;
    }

    public async Task Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUser.GetUserId();
        await _userService.UpdateUserAsync(userId, request.FullName, request.Email, cancellationToken);
    }
}