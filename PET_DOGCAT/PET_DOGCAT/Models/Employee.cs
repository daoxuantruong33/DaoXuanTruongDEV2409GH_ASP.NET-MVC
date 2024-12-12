using System;
using System.Collections.Generic;

namespace PET_DOGCAT.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateTime? HireDate { get; set; }
}
