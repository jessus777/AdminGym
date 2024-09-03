using AdminGym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGym.Domain.Entities;
public class User
    : AuditableEntity
{
    public Guid Id { get; set; } // Identificador único del usuario

    public string UserName { get; set; } // Nombre de usuario

    public string Email { get; set; } // Correo electrónico del usuario

    public string PasswordHash { get; set; } // Hash de la contraseña

    public bool IsActive { get; set; } // Indica si el usuario está activo o no
    public ICollection<UserRole> UserRoles { get; set; } // Relación muchos a muchos con roles
}
