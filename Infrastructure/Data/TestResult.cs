using System;
using System.Collections.Generic;

namespace Infrastructure.Data;

public partial class TestResult
{
    public int ResultId { get; set; }

    public int? VisitId { get; set; }

    public string? TestType { get; set; }

    public string? Result { get; set; }

    public DateOnly? TestDate { get; set; }

    public virtual Visit? Visit { get; set; }
}
