using System;

namespace StoreBackend.Dto.user;

public class UserDto
{
    public required Guid ExternalId { get; set; }
    public required string Name { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
}
