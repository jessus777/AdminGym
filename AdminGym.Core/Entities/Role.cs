using AdminGym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGym.Domain.Entities;
public class Role
    : AuditableEntity
{
    public Guid Id { get; set; } // Identificador único del rol

    public string Name { get; set; } // Nombre del rol (por ejemplo, "Admin", "Member")

    public string Description { get; set; } // Descripción del rol

    public ICollection<UserRole> UserRoles { get; set; } // Relación muchos a muchos con usuarios
}
