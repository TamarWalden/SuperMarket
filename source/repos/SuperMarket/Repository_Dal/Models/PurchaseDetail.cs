using System;
using System.Collections.Generic;

namespace Repository_Dal.Models;

public partial class PurchaseDetail
{
    public int Code { get; set; }

    public int? PurchaseCode { get; set; }

    public int? ProductCode { get; set; }

    public int? Quantity { get; set; }

    public virtual Product? ProductCodeNavigation { get; set; }

    public virtual Shopping? PurchaseCodeNavigation { get; set; }
}
