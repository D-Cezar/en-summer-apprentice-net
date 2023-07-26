using System;
using System.Collections.Generic;

namespace EndavaProject.Models;

public partial class Customer
{
    public long CustomersId { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
}