using System;
using System.Collections.Generic;

namespace Common_DTO.Models;

public class CustomerDTO
{
    public int Code { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<ShoppingDTO> Shoppings { get; set; } = new List<ShoppingDTO>();
}
