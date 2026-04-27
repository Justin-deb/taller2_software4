using System;

namespace StoreBackend.Api.Models.Responses.product;

public class ProductResponseModel
{
    public Guid ProductResourceId { get; set; }
    public String? Name { get; set; }
}
