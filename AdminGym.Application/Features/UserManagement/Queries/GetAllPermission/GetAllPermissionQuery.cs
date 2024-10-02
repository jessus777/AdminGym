using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Application.Request;

namespace AdminGym.Application.Features.UserManagement.Queries.GetAllPermission;
public class GetAllPermissionQuery
    : ApplicationRequest<IEnumerable<PermissionDto>>
{
    public GetAllPermissionQuery()
    {
        
    }
    public static GetAllPermissionQuery Instance { get; } = new();
}
