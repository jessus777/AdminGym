using AdminGym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGym.Domain.Entities;
public class Permission
    : AuditableEntity
{
    public Guid Id { get; set; } // Identificador único del permiso

    public string Name { get; set; } // Nombre del permiso (por ejemplo, "CreateUser", "EditUser")

    public string Description { get; set; } // Descripción del permiso

    public ICollection<RolePermission> RolePermissions { get; set; } // Relación muchos a muchos con roles
}
