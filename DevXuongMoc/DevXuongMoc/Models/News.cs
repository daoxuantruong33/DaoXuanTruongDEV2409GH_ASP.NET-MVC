using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models;

public partial class News
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }

    public string? MetaTitle { get; set; }

    public string? MainKeyword { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public string? Slug { get; set; }

    public int? Views { get; set; }

    public int? Likes { get; set; }

    public double? Star { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }

    public byte? Status { get; set; }

    public bool? Isdelete { get; set; }
}
