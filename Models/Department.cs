using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class Department
{
    public int DId { get; set; }

    public string? Department1 { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
