using System;
using System.Collections.Generic;

namespace ZaunService.Models;

public partial class User
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<TicketAssignment> TicketAssignments { get; set; } = new List<TicketAssignment>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
