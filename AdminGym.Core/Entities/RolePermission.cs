using AdminGym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGym.Domain.Entities;
public class RolePermission
    : AuditableEntity
{
    public Guid RoleId { get; set; } // Llave foránea al rol

    public Role Role { get; set; } // Referencia a la entidad rol

    public Guid PermissionId { get; set; } // Llave foránea al permiso

    public Permission Permission { get; set; } // Referencia a la entidad permiso
}
