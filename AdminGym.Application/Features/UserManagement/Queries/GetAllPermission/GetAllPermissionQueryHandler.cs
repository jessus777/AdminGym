using AdminGym.Application.Contracts.Persistence;
using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Application.Request;
using AutoMapper;
using FluentResults;

namespace AdminGym.Application.Features.UserManagement.Queries.GetAllPermission;
public class GetAllPermissionQueryHandler
    : ApplicationRequestHandler<GetAllPermissionQuery, IEnumerable<PermissionDto>>
{
    private readonly IUserManagmentUnitOfWork _userManagmentUnitOfWork;
    private readonly IMapper _mapper;

    public GetAllPermissionQueryHandler(
        IUserManagmentUnitOfWork userManagmentUnitOfWork,
        IMapper mapper
        )
    {
        _userManagmentUnitOfWork = userManagmentUnitOfWork;
        _mapper = mapper;
    }

    protected override async Task<Result<IEnumerable<PermissionDto>>> HandleAsync(
        GetAllPermissionQuery request,
        CancellationToken cancellationToken
        )
    {
        var permissions = await _userManagmentUnitOfWork
            .PermissionRepository
            .GetAllPermissionAsync(cancellationToken);

        var permissionListDto = _mapper.Map<IEnumerable<PermissionDto>>(permissions);

        return Ok(permissionListDto);
    }
}
