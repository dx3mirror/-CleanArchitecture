using System;
using System.Collections.Generic;

namespace Infrastructure.Data;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Specialty { get; set; }

    public DateOnly? HireDate { get; set; }

    public string? ContactNumber { get; set; }

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
