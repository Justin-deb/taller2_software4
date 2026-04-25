using System;

namespace StoreBackend.Dto;

public class ProductDto
{
    public Guid ProductResourceId { get; set; }
    public String? Name { get; set; }
}
