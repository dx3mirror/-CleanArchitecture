using System;
using System.Collections.Generic;

namespace Infrastructure.Data;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
