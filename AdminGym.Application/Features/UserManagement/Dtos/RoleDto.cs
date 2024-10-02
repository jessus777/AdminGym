namespace AdminGym.Application.Features.UserManagement.Dtos;
public class RoleDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<UserRoleDto> UserRoles { get; set; } = [];
}
