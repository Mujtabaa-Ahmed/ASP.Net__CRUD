using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? EName { get; set; }

    public string? EEmail { get; set; }

    public string? EDesig { get; set; }

    public int? DId { get; set; }

    public virtual Department? DIdNavigation { get; set; }
}
