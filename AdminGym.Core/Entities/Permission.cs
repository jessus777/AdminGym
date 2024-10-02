using AdminGym.Domain.Common;
using AdminGym.Domain.Enums;

namespace AdminGym.Domain.Entities;
public class Permission
    : AuditableEntity
{
    public Guid Id { get; set; } = new Guid();

    public string Name { get; set; } // Nombre del permiso (por ejemplo, "CreateUser", "EditUser")

    public string Description { get; set; } // Descripción del permiso

    public PermissionType PermissionType { get; set; }

    public ICollection<RolePermission> RolePermissions { get; set; } // Relación muchos a muchos con roles
    public long Consecutivo { get; set; }
    public bool IsActive { get; set; } = true;
}
