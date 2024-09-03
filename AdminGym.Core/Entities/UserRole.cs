using AdminGym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGym.Domain.Entities;
public class UserRole
    : AuditableEntity
{
    public Guid UserId { get; set; } // Llave foránea al usuario

    public User User { get; set; } // Referencia a la entidad usuario

    public Guid RoleId { get; set; } // Llave foránea al rol

    public Role Role { get; set; } // Referencia a la entidad rol
}
