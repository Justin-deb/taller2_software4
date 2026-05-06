using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto.user;

namespace StoreBackend.Facade.Mappers;

public class UserMapper
{
    public static List<UserDto> ToDto(List<User> users)
    {
        return users.Select(u => ToDto(u)).ToList();
    }

    public static UserDto ToDto(User user)
    {
        return new UserDto
        {
            ExternalId = user.ExternalId,
            Name = user.Name,
            Username = user.Username,
            Email = user.Email,
        };
    }
}
