using System;
using System.Collections.Generic;

namespace EndavaProject.Models;

public partial class Event
{
    public long EventId { get; set; }

    public string? Description { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Name { get; set; }

    public DateTime? StartDate { get; set; }

    public long? EventTypeId { get; set; }

    public long? VenueId { get; set; }

    public virtual EventType? EventType { get; set; }

    public virtual ICollection<TicketCategory> TicketCategories { get; set; } = new List<TicketCategory>();

    public virtual Venue? Venue { get; set; }
}
