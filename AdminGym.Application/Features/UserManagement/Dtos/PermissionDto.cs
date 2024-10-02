using AdminGym.Domain.Common;

namespace AdminGym.Application.Features.UserManagement.Dtos;
public class PermissionDto
    : AuditableEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    public int Consecutivo { get; set; }
}
