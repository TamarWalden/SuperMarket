using System;
using System.Collections.Generic;

namespace Repository_Dal.Models;

public partial class Shopping
{
    public int Code { get; set; }

    public DateOnly? Date { get; set; }

    public int? CustomerCode { get; set; }

    public string? DeliveryAddress { get; set; }

    public virtual Customer? CustomerCodeNavigation { get; set; }

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
