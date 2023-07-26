using System;
using System.Collections.Generic;

namespace EndavaProject.Models;

public partial class Order
{
    public long OrdersId { get; set; }

    public int? NumberOfTickets { get; set; }

    public DateTime? OrderedAt { get; set; }

    public double? TotalPrice { get; set; }

    public long? CustomersId { get; set; }

    public long? TicketCategoryId { get; set; }

    public virtual Customer? Customers { get; set; }

    public virtual TicketCategory? TicketCategory { get; set; }
}
