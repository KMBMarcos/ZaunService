
namespace ZaunService.Models;

public partial class Ticket
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long? ServiceId { get; set; }

    // Datos de la solicitud
    public string Description { get; set; } = null!;

    // Datos del solicitante
    public string? NombreSolicitante { get; set; }
    public string? Institucion { get; set; }
    public string? Provincia { get; set; }
    public string? Municipio { get; set; }
    public string? Sector { get; set; }
    public string? Telefono { get; set; }
    public string? Celular { get; set; }
    public string? CorreoContacto { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public virtual Service? Service { get; set; }

    public virtual ICollection<TicketAssignment> TicketAssignments { get; set; } = new List<TicketAssignment>();

    public virtual User? User { get; set; }
}
