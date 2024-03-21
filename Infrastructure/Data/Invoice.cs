using System;
using System.Collections.Generic;

namespace Infrastructure.Data;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int? VisitId { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? IssueDate { get; set; }

    public string? Status { get; set; }

    public virtual Visit? Visit { get; set; }
}
