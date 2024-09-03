using AdminGym.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminGym.Persistence.DbContexts;
public class ApplicationDbEFContext
    : DbContext
{
    public ApplicationDbEFContext(DbContextOptions<ApplicationDbEFContext> options) 
        : base(options)
    {

    }

    // Definición de DbSets para cada entidad
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<Membership> Memberships { get; set; }
}
