using System;
using System.Collections.Generic;

namespace EndavaProject.Models;

public partial class TicketCategory
{
    public long TicketCategoryId { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public long? EventId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
}