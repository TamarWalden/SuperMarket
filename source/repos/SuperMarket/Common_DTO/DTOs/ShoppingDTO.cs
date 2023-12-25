using System;
using System.Collections.Generic;

namespace Common_DTO.Models;

public class ShoppingDTO
{
    public int Code { get; set; }

    public DateOnly? Date { get; set; }

    public int? CustomerCode { get; set; }

    public string? DeliveryAddress { get; set; }
}
