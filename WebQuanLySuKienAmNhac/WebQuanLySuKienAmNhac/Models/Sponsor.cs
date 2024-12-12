using System;
using System.Collections.Generic;

namespace WebQuanLySuKienAmNhac.Models;

public partial class Sponsor
{
    public int SponsorId { get; set; }

    public string SponsorName { get; set; } = null!;

    public string ContactEmail { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<EventSponsor> EventSponsors { get; set; } = new List<EventSponsor>();
}
