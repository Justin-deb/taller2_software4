using System;

namespace StoreBackend.Dto.user;

public class UserDto
{
    public Guid ExternalId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Passwordhash { get; set; }
}
