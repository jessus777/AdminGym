using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Application.Request;

namespace AdminGym.Application.Features.UserManagement.Commands.CreateRole;
public class CreateRoleCommand
    : ApplicationRequest<RoleDto>
{
    public CreateRoleCommand(CreateRoleDto createRole)
    {
        CreateRole = createRole;
    }

    public CreateRoleDto CreateRole { get; set; }
}
