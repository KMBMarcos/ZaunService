using System;
using System.Collections.Generic;

namespace ZaunService.Models;

public partial class TicketAssignment
{
    public long Id { get; set; }

    public long? TicketId { get; set; }

    public long? AdminId { get; set; }

    public DateTime? AssignedAt { get; set; }

    public int Stage { get; set; }

    public virtual User? Admin { get; set; }

    public virtual Ticket? Ticket { get; set; }
}
