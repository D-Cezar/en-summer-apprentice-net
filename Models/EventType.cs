using System;
using System.Collections.Generic;

namespace EndavaProject.Models;

public partial class EventType
{
    public long EventTypeId { get; set; }

    public string? EventTypeName { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
