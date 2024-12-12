using System;
using System.Collections.Generic;

namespace WebQuanLySuKienAmNhac.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public string Venue { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<EventArtist> EventArtists { get; set; } = new List<EventArtist>();

    public virtual ICollection<EventSponsor> EventSponsors { get; set; } = new List<EventSponsor>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
