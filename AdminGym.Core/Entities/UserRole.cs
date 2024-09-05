using AdminGym.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGym.Domain.Entities;
public class UserRole
    : IdentityUserRole<Guid>
{

    public User User { get; set; } // Referencia a la entidad usuario


    public Role Role { get; set; } // Referencia a la entidad rol
}
