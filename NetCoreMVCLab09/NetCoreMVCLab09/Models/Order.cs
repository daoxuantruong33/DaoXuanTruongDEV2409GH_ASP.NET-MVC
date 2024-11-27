using System;
using System.Collections.Generic;

namespace NetCoreMVCLab09.Models;

public partial class Order
{
    public int Id { get; set; }

    public string Idorders { get; set; } = null!;

    public DateTime? OrdersDate { get; set; }

    public int Idcustomer { get; set; }

    public int? Idpayment { get; set; }

    public decimal TotalMoney { get; set; }

    public string? Notes { get; set; }

    public string? NameReceiver { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool? Isdelete { get; set; }

    public bool? Isactive { get; set; }

    public virtual Customer IdcustomerNavigation { get; set; } = null!;

    public virtual ICollection<OrdersDetail> OrdersDetails { get; set; } = new List<OrdersDetail>();
}
