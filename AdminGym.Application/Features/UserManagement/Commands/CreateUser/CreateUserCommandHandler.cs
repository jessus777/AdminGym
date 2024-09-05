using AdminGym.Application.Contracts.Persistence;
using AdminGym.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AdminGym.Application.Features.UserManagement.Commands.CreateUser;
public sealed class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, IdentityResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task<IdentityResult> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken
        )                                                       
    {
        await _unitOfWork.BeginTransactionAsync();

        var user = new User()
        {
            Email = request.Email,
            FirstName = request.UserName,
            DateOfBirth = DateTime.UtcNow,
            UserName = request.UserName
        };

        var result = await _userManager.CreateAsync(user, request.PassWord);

        if (result.Succeeded)
        {
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
        }
        return result;
    }
}
