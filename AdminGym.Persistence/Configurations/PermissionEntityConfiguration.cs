using AdminGym.Domain.Entities;
using AdminGym.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminGym.Persistence.Configurations;
public class PermissionEntityConfiguration
    : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasData(
            new Permission
            {
                Id = Guid.Parse("38C56B87-E1AC-4F7E-8210-5592CC336147"),
                Consecutivo = 1,
                CreatedByUserId = Guid.Parse("2C4C9995-BB28-48EC-B996-08DCE30FF7B4"),
                CreatedDate = DateTime.Now,
                PermissionType = PermissionType.Consulta,
                Name = "Consulta",
                Description = "Permiso para consultar los datos",
                IsActive = true,
                UpdatedByUserId = Guid.Parse("2C4C9995-BB28-48EC-B996-08DCE30FF7B4"),
                UpdatedDate = DateTime.Now,
            },
            new Permission
            {
                Id = Guid.Parse("079037CA-3268-412D-8E94-027F0AE516BC"),
                Consecutivo = 2,
                CreatedByUserId = Guid.Parse("2C4C9995-BB28-48EC-B996-08DCE30FF7B4"),
                CreatedDate = DateTime.Now,
                PermissionType = PermissionType.Escritura,
                Name = "Escritura",
                Description = "Permiso para capturar los datos",
                IsActive = true,
                UpdatedByUserId = Guid.Parse("2C4C9995-BB28-48EC-B996-08DCE30FF7B4"),
                UpdatedDate = DateTime.Now,
            },
            new Permission
            {
                Id = Guid.Parse("7F51C649-2241-49CD-A6B9-4480619F8DAD"),
                Consecutivo = 3,
                CreatedByUserId = Guid.Parse("2C4C9995-BB28-48EC-B996-08DCE30FF7B4"),
                CreatedDate = DateTime.Now,
                PermissionType = PermissionType.Modificación,
                Name = "Modificación",
                Description = "Permiso para editar los datos",
                IsActive = true,
                UpdatedByUserId = Guid.Parse("2C4C9995-BB28-48EC-B996-08DCE30FF7B4"),
                UpdatedDate = DateTime.Now,
            },
            new Permission
            {
                Id = Guid.Parse("59F84721-14D7-40CF-ABA7-D2F7857BED0F"),
                Consecutivo = 4,
                CreatedByUserId = Guid.Parse("2C4C9995-BB28-48EC-B996-08DCE30FF7B4"),
                CreatedDate = DateTime.Now,
                PermissionType = PermissionType.Eliminación,
                Name = "Eliminación",
                Description = "Permiso para eliminar los datos",
                IsActive = true,
                UpdatedByUserId = Guid.Parse("2C4C9995-BB28-48EC-B996-08DCE30FF7B4"),
                UpdatedDate = DateTime.Now,
            }
            );
    }
}
