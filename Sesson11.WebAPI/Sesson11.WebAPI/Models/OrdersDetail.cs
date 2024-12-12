using System;
using System.Collections.Generic;

namespace Sesson11.WebAPI.Models;

public partial class OrdersDetail
{
    public int Id { get; set; }

    public int Idord { get; set; }

    public int Idproduct { get; set; }

    public decimal Price { get; set; }

    public int Qty { get; set; }

    public decimal? Total { get; set; }

    public int? ReturnQty { get; set; }

    public virtual Order IdordNavigation { get; set; } = null!;

    public virtual Product IdproductNavigation { get; set; } = null!;
}
