using AdminGym.Application.Contracts.Persistence;
using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Application.Request;
using AdminGym.Domain.Entities;
using AdminGym.Domain.Errors;
using AutoMapper;
using FluentResults;

namespace AdminGym.Application.Features.UserManagement.Commands.CreateUser;
public sealed class CreateUserCommandHandler
    : ApplicationRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserManagmentUnitOfWork _userManagmentUnitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(
        IUserManagmentUnitOfWork userManagmentUnitOfWork,
        IMapper mapper
        )
    {
        _userManagmentUnitOfWork = userManagmentUnitOfWork;
        _mapper = mapper;
    }

    protected override async Task<Result<UserDto>> HandleAsync(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _userManagmentUnitOfWork.BeginTransactionAsync();

        var user = _mapper.Map<User>(request.UserCommand);

        var result = await _userManagmentUnitOfWork.UserRepository.CreateUserAsync(user, request.UserCommand.Password);


        if (result.Succeeded)
        {
            await _userManagmentUnitOfWork.SaveChangesAsync();
            await _userManagmentUnitOfWork.CommitTransactionAsync();
            var userDto = _mapper.Map<UserDto>(user);

        }
        else
        {
            await _userManagmentUnitOfWork.RollbackTransactionAsync();
        }
        return DomainError.EntityNotFound("xzssda");
    }
}
