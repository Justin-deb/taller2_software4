using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto.user;

namespace StoreBackend.Facade.Mappers;

public class UserMapper
{
    public static List<UserDto> ToDto(List<User> products)
    {
        return products.Select(u => ToDto(u)).ToList();
    }

    public static UserDto ToDto(User user)
    {
        return new UserDto
        {
            ExternalId = user.ExternalId,
            Username = user.Username,
            Email = user.Email,
            Passwordhash = user.Passwordhash,
        };
    }
}
