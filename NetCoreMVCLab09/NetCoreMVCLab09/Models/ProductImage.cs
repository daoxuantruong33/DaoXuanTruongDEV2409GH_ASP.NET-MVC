using System;
using System.Collections.Generic;

namespace NetCoreMVCLab09.Models;

public partial class ProductImage
{
    public int Id { get; set; }

    public int? Pid { get; set; }

    public string? Image { get; set; }
}
