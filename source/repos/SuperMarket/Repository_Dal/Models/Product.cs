using System;
using System.Collections.Generic;

namespace Repository_Dal.Models;

public partial class Product
{
    public int Code { get; set; }

    public string? Name { get; set; }

    public int? DepartmentCode { get; set; }

    public int? CompanyCode { get; set; }

    public decimal? Price { get; set; }

    public int? QuantityInStock { get; set; }

    public string? Description { get; set; }

    public string? Picture { get; set; }

    public virtual Company? CompanyCodeNavigation { get; set; }

    public virtual Department? DepartmentCodeNavigation { get; set; }

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
