using AdminGym.Application.Contracts.Persistence;
using AdminGym.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AdminGym.Application.Features.UserManagement.Commands.CreateUser;
public sealed class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, IdentityResult>
{
    private readonly IUserManagmentUnitOfWork _userManagmentUnitOfWork;

    public CreateUserCommandHandler(IUserManagmentUnitOfWork userManagmentUnitOfWork)
    {
        _userManagmentUnitOfWork = userManagmentUnitOfWork;
    }

    public async Task<IdentityResult> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken
        )
    {
        await _userManagmentUnitOfWork.BeginTransactionAsync();

        var user = new User()
        {
            Email = request.Email,
            FirstName = request.UserName,
            DateOfBirth = DateTime.UtcNow,
            UserName = request.UserName
        };

        var result = await _userManagmentUnitOfWork.UserRepository.CreateUserAsync(user, request.PassWord);


        if (result.Succeeded)
        {
            await _userManagmentUnitOfWork.SaveChangesAsync();
            await _userManagmentUnitOfWork.CommitTransactionAsync();
        }
        else
        {
            await _userManagmentUnitOfWork.RollbackTransactionAsync();
        }
        return result;
    }
}
