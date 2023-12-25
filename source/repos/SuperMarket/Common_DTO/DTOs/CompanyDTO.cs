using System;
using System.Collections.Generic;

namespace Common_DTO.Models;

public class CompanyDTO
{
    public int Code { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();
}
