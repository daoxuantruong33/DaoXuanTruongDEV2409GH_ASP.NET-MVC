using System;
using System.Collections.Generic;

namespace PET_DOGCAT.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? CustomerId { get; set; }

    public int? PetId { get; set; }

    public int? ServiceId { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Pet? Pet { get; set; }

    public virtual Service? Service { get; set; }
}
