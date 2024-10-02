using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Application.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGym.Application.Features.UserManagement.Commands.CreatePermission;
public class CreatePermissionCommand
    : ApplicationRequest<PermissionDto>
{
    public CreatePermissionCommand(CreatePermissionDto createPermissionDto)
    {
        CreatePermissionDto = createPermissionDto;
    }

    public CreatePermissionDto CreatePermissionDto { get; set; }
}
