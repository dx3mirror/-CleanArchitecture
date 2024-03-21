using System;
using System.Collections.Generic;

namespace Infrastructure.Data;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int? VisitId { get; set; }

    public int? DiagnosisId { get; set; }

    public string? MedicationName { get; set; }

    public string? Dosage { get; set; }

    public string? Instructions { get; set; }

    public DateOnly? PrescriptionDate { get; set; }

    public virtual Diagnosis? Diagnosis { get; set; }

    public virtual Visit? Visit { get; set; }
}
