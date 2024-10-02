using AdminGym.Application.Contracts.Persistence;
using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Application.Request;
using AdminGym.Domain.Entities;
using AdminGym.Domain.Errors;
using AutoMapper;
using FluentResults;

namespace AdminGym.Application.Features.UserManagement.Commands.CreateRole;
public class CreateRoleCommandHandler
    : ApplicationRequestHandler<CreateRoleCommand, RoleDto>
{
    private readonly IUserManagmentUnitOfWork _userManagmentUnitOfWork;
    private readonly IMapper _mapper;

    public CreateRoleCommandHandler(
        IUserManagmentUnitOfWork userManagmentUnitOfWork,
        IMapper mapper
        )
    {
        _userManagmentUnitOfWork = userManagmentUnitOfWork;
        _mapper = mapper;
    }

    protected override async Task<Result<RoleDto>> HandleAsync(
        CreateRoleCommand request,
        CancellationToken cancellationToken
        )
    {
        await _userManagmentUnitOfWork.BeginTransactionAsync();
        var roleAsync = await _userManagmentUnitOfWork
            .RoleRepository.ExistRoleAsync(request.CreateRole.Name, cancellationToken);

        if (roleAsync is not null)
        {
            await _userManagmentUnitOfWork.RollbackTransactionAsync();
            return DomainError.EntityNotFound(request.CreateRole.Name);
        }

        var role = _mapper.Map<Role>(request.CreateRole);
        var createRole = await _userManagmentUnitOfWork
            .RoleRepository.CreateRoleAsync(role, cancellationToken);
        if (createRole is null) 
        { 
            return DomainError.EntityConflict(request.CreateRole.Name, "No se pudo crear el role.");
        }

        await _userManagmentUnitOfWork.SaveChangesAsync();
        await _userManagmentUnitOfWork.CommitTransactionAsync();

        var roleDto = _mapper.Map<RoleDto>(createRole);
        return Ok(roleDto);
            
    }
}
