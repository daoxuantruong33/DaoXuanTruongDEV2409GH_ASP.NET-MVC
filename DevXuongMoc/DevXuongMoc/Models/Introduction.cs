using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models;

public partial class Introduction
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Image { get; set; } = null!;

    public int? Orders { get; set; }

    public string? Description { get; set; }

    public byte? Home { get; set; }

    public byte? Type { get; set; }

    public int? Parentid { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public string? Slug { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }

    public string? Content { get; set; }

    public byte Status { get; set; }

    public bool Isdelete { get; set; }
}
