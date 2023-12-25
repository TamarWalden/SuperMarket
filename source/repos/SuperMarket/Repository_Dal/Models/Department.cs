using System;
using System.Collections.Generic;

namespace Repository_Dal.Models;

public partial class Department
{
    public int Code { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
