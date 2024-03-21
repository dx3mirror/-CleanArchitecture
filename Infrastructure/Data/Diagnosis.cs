using System;
using System.Collections.Generic;

namespace Infrastructure.Data;

public partial class Diagnosis
{
    public int DiagnosisId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
