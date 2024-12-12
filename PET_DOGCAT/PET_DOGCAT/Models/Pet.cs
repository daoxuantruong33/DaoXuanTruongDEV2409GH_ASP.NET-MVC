using System;
using System.Collections.Generic;

namespace PET_DOGCAT.Models;

public partial class Pet
{
    public int PetId { get; set; }

    public int? CustomerId { get; set; }

    public string? PetName { get; set; }

    public string? Breed { get; set; }

    public DateOnly? BirthDate { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Customer? Customer { get; set; }
}
