using AdminGym.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGym.Domain.Entities;
public class RolePermission
    : AuditableEntity
{
    public Guid RoleId { get; set; }
    public Role Role { get; set; }

    public Guid PermissionId { get; set; }
    public Permission Permission { get; set; }
}
