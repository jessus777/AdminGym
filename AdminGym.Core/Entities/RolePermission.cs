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
    public Guid Id { get; set; }  // Clave primaria
    public Guid RoleId { get; set; }
    public Role Role { get; set; } // Referencia a la entidad rol

    public Guid PermissionId { get; set; } // Llave foránea al permiso

    public Permission Permission { get; set; } // Referencia a la entidad permiso
}
