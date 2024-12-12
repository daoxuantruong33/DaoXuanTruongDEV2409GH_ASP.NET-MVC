using System;
using System.Collections.Generic;

namespace WebQuanLySuKienAmNhac.Models;

public partial class EventArtist
{
    public int EventArtistId { get; set; }

    public int EventId { get; set; }

    public int UserId { get; set; }

    public string? Role { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
