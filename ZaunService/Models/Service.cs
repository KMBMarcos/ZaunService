using System;
using System.Collections.Generic;

namespace ZaunService.Models;

public partial class Service
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
