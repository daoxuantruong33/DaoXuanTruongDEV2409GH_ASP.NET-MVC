using System;
using System.Collections.Generic;

namespace PET_DOGCAT.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
