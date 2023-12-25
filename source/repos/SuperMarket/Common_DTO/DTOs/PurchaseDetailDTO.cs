using System;
using System.Collections.Generic;

namespace Common_DTO.Models;

public class PurchaseDetailDTO
{
    public int Code { get; set; }

    public int? PurchaseCode { get; set; }

    public int? ProductCode { get; set; }

    public int? Quantity { get; set; }
}
