using AdminGym.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminGym.Persistence.Configurations;
public class UserEntityConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                Id = Guid.Parse("2C4C9995-BB28-48EC-B996-08DCE30FF7B4"),
                PasswordHash = "AQAAAAIAAYagAAAAENpFn/u7fakTfDIwCPuaPStDtsITAZfLTIjWae8tj4V1QsEY+pv7F+Ua9uQAexh+AA==",
                SecurityStamp = "HMNPVRUUVQXQZN2JF3YRB27KUX2FXGAB",
                ConcurrencyStamp = "14dd5825-5153-41c8-aa39-0bf9a4394c10",
                PhoneNumber = "7471773358",
                Email = "jessusjim777@gmail.com",
                IsActive = true,
                AccessFailedCount = 0,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                EmailConfirmed = false,
                LockoutEnabled = true,
                LockoutEnd = null,
                NormalizedEmail = "JESSUSJIM777@GMAIL.COM",
                NormalizedUserName = "JESUSJIMENEZRENDON",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                FirstName = "Jesus",
                SecondName = "",
                PaternalSurname = "Jimenez",
                MaternalSurname = "Rendon",
                DateOfBirth = DateTime.Parse("1993-02-09 00:24:37.5190000"),
                CreatedByUserId = Guid.Parse("2C4C9995-BB28-48EC-B996-08DCE30FF7B4"),
                UpdatedByUserId = Guid.Parse("2C4C9995-BB28-48EC-B996-08DCE30FF7B4")
            }
        );
    }
}
