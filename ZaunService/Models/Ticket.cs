using System;
using System.Collections.Generic;

namespace ZaunService.Models;

public partial class Ticket
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long? ServiceId { get; set; }

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Service? Service { get; set; }

    public virtual ICollection<TicketAssignment> TicketAssignments { get; set; } = new List<TicketAssignment>();

    public virtual User? User { get; set; }
}
