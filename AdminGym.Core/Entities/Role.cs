using Microsoft.AspNetCore.Identity;

namespace AdminGym.Domain.Entities;
public class Role
    : IdentityRole<Guid>
{
    //public Guid Id { get; set; } // Identificador único del rol

    //public string Name { get; set; } // Nombre del rol (por ejemplo, "Admin", "Member")

    public string Description { get; set; } // Descripción del rol

    public ICollection<UserRole> UserRoles { get; set; } // Relación muchos a muchos con usuarios
    public ICollection<RolePermission> RolePermissions { get; set; }
}
