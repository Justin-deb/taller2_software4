using System;

namespace StoreBackend.Api.Models.Responses.user;

public class UserResponseModel
{
    public Guid ExternalId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Passwordhash { get; set; }
}
