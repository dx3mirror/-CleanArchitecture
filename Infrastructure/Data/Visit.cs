using System;
using System.Collections.Generic;

namespace Infrastructure.Data;

public partial class Visit
{
    public int VisitId { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public int? DepartmentId { get; set; }

    public DateTime? VisitDatetime { get; set; }

    public string? Notes { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Patient? Patient { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();
}
