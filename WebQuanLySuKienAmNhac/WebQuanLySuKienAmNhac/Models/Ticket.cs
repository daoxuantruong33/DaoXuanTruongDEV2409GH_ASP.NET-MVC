using System;
using System.Collections.Generic;

namespace WebQuanLySuKienAmNhac.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int EventId { get; set; }

    public int UserId { get; set; }

    public string TicketType { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime? IssuedAt { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
