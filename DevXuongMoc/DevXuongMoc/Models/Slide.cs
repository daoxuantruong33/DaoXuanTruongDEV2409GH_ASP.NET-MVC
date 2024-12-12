using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models;

public partial class Slide
{
    public int Id { get; set; }

    public string? Image { get; set; }

    public string? Title { get; set; }

    public string? SubTitle { get; set; }

    public string? Urls { get; set; }

    public int Orders { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }

    public string? Notes { get; set; }

    public byte Status { get; set; }

    public bool Isdelete { get; set; }
}
