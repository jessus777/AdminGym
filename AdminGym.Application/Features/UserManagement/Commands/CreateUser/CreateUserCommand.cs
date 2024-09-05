using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AdminGym.Application.Features.UserManagement.Commands.CreateUser;
public sealed class CreateUserCommand
    : IRequest<IdentityResult>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string PassWord { get; set; }
}
