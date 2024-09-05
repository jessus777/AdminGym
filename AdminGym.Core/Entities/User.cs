using AdminGym.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace AdminGym.Domain.Entities;
public class User
    : IdentityUser<Guid>
{

    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public bool IsActive { get; set; } // Indica si el usuario está activo o no
    public ICollection<UserRole> UserRoles { get; set; } // Relación muchos a muchos con roles
    public DateTime CreatedDate { get; set; }

    // Fecha de la última actualización de la entidad
    public DateTime? UpdatedDate { get; set; }

    // Identificador del usuario que creó la entidad
    public Guid CreatedByUserId { get; set; }

    // Identificador del usuario que realizó la última actualización
    public Guid? UpdatedByUserId { get; set; }
}
