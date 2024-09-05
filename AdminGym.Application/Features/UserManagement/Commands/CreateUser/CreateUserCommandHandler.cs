using AdminGym.Application.Contracts.Persistence;
using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Application.Wrappers;
using AdminGym.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AdminGym.Application.Features.UserManagement.Commands.CreateUser;
public sealed class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, Result<UserDto>>
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

    public async Task<Result<UserDto>> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken
        )
    {
        await _userManagmentUnitOfWork.BeginTransactionAsync();

        var user = _mapper.Map<User>(request.UserCommand);

        var result = await _userManagmentUnitOfWork.UserRepository.CreateUserAsync(user, request.UserCommand.Password);


        if (result.Succeeded)
        {
            await _userManagmentUnitOfWork.SaveChangesAsync();
            await _userManagmentUnitOfWork.CommitTransactionAsync();
        }
        else
        {
            await _userManagmentUnitOfWork.RollbackTransactionAsync();
        }
        var userDto = _mapper.Map<UserDto>(user);
        return Result<UserDto>.Success(userDto);
    }
}
