using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Application.Wrappers;
using MediatR;

namespace AdminGym.Application.Features.UserManagement.Commands.CreateUser;
public sealed class CreateUserCommand
    : IRequest<Result<UserDto>>
{
    public CreateUserCommand(CreateUserCommandDto userCommand)
    {
        UserCommand = userCommand;
    }

    public CreateUserCommandDto UserCommand { get; set; }
}
