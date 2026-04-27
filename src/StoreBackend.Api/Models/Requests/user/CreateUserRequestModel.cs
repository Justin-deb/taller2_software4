using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Models.Requests.user;

public class CreateUserRequestModel
{
    [Required]
    public Guid ExternalId { get; set; }
    [Required]
    [MaxLength(50)]
    public String? Username { get; set; }
    [Required]
    [MaxLength(100)]
    public String? Email { get; set; }
    [Required]
    [MaxLength(256)]
    public String? Passwordhash { get; set; }
}
