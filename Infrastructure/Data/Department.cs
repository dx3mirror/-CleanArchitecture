using System;
using System.Collections.Generic;

namespace Infrastructure.Data;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
