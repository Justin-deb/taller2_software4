using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Models.Requests.product;

public class CreateProductRequestModel
{
    [Required]
    public Guid? ProductResourceId { get; set; }

    [Required]
    [MaxLength(50)]
    public String? Name { get; set; }
}
