using AdminGym.Domain.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;


namespace AdminGym.Persistence.DbContexts;
public class ApplicationDbEFContext
    : IdentityDbContext<User, Role, Guid>
{
    public ApplicationDbEFContext(
        DbContextOptions<ApplicationDbEFContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    public DbSet<Permission> Permissions { get; set; }
    //public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Agrega aquí cualquier configuración adicional
        builder.Entity<UserRole>()
           .HasOne(ur => ur.User)
           .WithMany(u => u.UserRoles)
           .HasForeignKey(ur => ur.UserId);

        builder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        builder.Entity<Membership>()
       .Property(m => m.Price)
       .HasColumnType("decimal(18,2)");
    }

}
