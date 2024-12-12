using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models;

public partial class Partner
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Logo { get; set; }

    public string? Url { get; set; }

    public byte? Orders { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }

    public string? Content { get; set; }

    public byte? Status { get; set; }

    public bool? Isdelete { get; set; }
}
