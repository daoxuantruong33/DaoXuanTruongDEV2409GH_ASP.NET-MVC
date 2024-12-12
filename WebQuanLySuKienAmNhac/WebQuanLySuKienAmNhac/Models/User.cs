using System;
using System.Collections.Generic;

namespace WebQuanLySuKienAmNhac.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string UserType { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<EventArtist> EventArtists { get; set; } = new List<EventArtist>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
