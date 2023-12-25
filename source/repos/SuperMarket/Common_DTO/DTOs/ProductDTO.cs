using System;
using System.Collections.Generic;

namespace Common_DTO.Models;

public class ProductDTO
{
    public int Code { get; set; }

    public string? Name { get; set; }

    public int? DepartmentCode { get; set; }

    public string? DepartmentName { get; set; }

    public int? CompanyCode { get; set; }
    public string? CompanyName { get; set; }

    public decimal? Price { get; set; }

    public int? QuantityInStock { get; set; }

    public string? Description { get; set; }

    public string? Picture { get; set; }

}
