using MediatR;
using SetWhen.Application.Features.Users.Commands;
using SetWhen.Application.Interfaces;

namespace SetWhen.Application.Features.Users.Handlers;
public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand>
{
    private readonly IUserService _userService;

    public UpdateUserProfileHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        await _userService.UpdateUserAsync(request.UserId, request.Data.FullName, request.Data.Email, cancellationToken);
    }
}