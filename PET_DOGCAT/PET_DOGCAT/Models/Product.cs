using System;
using System.Collections.Generic;

namespace PET_DOGCAT.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Category { get; set; }

    public decimal? Price { get; set; }

    public int? StockQuantity { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
