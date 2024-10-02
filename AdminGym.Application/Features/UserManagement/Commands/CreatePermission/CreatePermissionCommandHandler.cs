using AdminGym.Application.Contracts.Persistence;
using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Application.Request;
using AdminGym.Domain.Entities;
using AdminGym.Domain.Errors;
using AutoMapper;
using FluentResults;

namespace AdminGym.Application.Features.UserManagement.Commands.CreatePermission;
public class CreatePermissionCommandHandler
    : ApplicationRequestHandler<CreatePermissionCommand, PermissionDto>
{
    private readonly IUserManagmentUnitOfWork _userManagmentUnitOfWork;
    private readonly IMapper _mapper;

    public CreatePermissionCommandHandler(
        IUserManagmentUnitOfWork userManagmentUnitOfWork,
        IMapper mapper
        )
    {
        _userManagmentUnitOfWork = userManagmentUnitOfWork;
        _mapper = mapper;
    }

    protected override async Task<Result<PermissionDto>> HandleAsync(
        CreatePermissionCommand request,
        CancellationToken cancellationToken
        )
    {

        await _userManagmentUnitOfWork.BeginTransactionAsync();
        var permission = _mapper.Map<Permission>(request.CreatePermissionDto);

        var result = await _userManagmentUnitOfWork.PermissionRepository
            .CreatePermissionAsync(permission, cancellationToken);

        if (result is null)
        {
            await _userManagmentUnitOfWork.RollbackTransactionAsync();
            return DomainError.EntityNotFound("No se pudo crear el permiso");
        }

        var permissionDto = _mapper.Map<PermissionDto>(result);

        await _userManagmentUnitOfWork.SaveChangesAsync();
        await _userManagmentUnitOfWork.CommitTransactionAsync();

        return Ok(permissionDto);


    }
}
