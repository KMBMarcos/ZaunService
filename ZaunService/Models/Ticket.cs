﻿
namespace ZaunService.Models;

public partial class Ticket
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long? ServiceId { get; set; }

    public string Description { get; set; } = null!; // Campo para el mensaje del ticket


    // Añadir campo para la institución
    // Añadir campo para la provincia
    // Añadir campo para el municipio
    // Añadir campo para el sector
    // Añadir campo para el celular
    // Añadir campo para el teléfono
    // Añadir campo para el correo electrónico

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Service? Service { get; set; }

    public virtual ICollection<TicketAssignment> TicketAssignments { get; set; } = new List<TicketAssignment>();

    public virtual User? User { get; set; }
}
