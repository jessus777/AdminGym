using Microsoft.AspNetCore.Identity;

namespace AdminGym.Domain.Entities;
public class UserRole
    : IdentityUserRole<Guid>
{

    public virtual User User { get; set; } // Referencia a la entidad usuario


    public virtual Role Role { get; set; } // Referencia a la entidad rol
}
