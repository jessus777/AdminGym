namespace AdminGym.Domain.Common;
public class AuditableEntity
{
    public DateTime CreatedDate { get; set; }

    // Fecha de la última actualización de la entidad
    public DateTime? UpdatedDate { get; set; }

    // Identificador del usuario que creó la entidad
    public Guid CreatedByUserId { get; set; }

    // Identificador del usuario que realizó la última actualización
    public Guid? UpdatedByUserId { get; set; }

    // Constructor para inicializar la fecha de creación
    protected AuditableEntity()
    {
        CreatedDate = DateTime.UtcNow; // Se inicializa la fecha de creación al momento de instanciar la entidad
        UpdatedDate = DateTime.UtcNow;
    }

}
