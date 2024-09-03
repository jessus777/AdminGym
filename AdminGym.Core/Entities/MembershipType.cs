using AdminGym.Domain.Common;

namespace AdminGym.Domain.Entities;
public class MembershipType
    : AuditableEntity
{
    public int Id { get; set; }  // Llave primaria
    public string Name { get; set; }  // Nombre del tipo de membresía (por ejemplo, "Mensual", "Anual")
    public string Description { get; set; }  // Descripción opcional
}
