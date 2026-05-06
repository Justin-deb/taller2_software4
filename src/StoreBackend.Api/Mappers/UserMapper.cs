using System;
using StoreBackend.Api.Models.Requests.user;
using StoreBackend.Api.Models.Responses.user;
using StoreBackend.Dto.user;

namespace StoreBackend.Api.Mappers;

public class UserMapper
{
    public static List<UserResponseModel> ToModel(List<UserDto> users)
    {
        return users.Select(u => ToModel(u)).ToList();
    }

    public static UserResponseModel ToModel(UserDto user)
    {
        return new UserResponseModel
        {
            ExternalId = user.ExternalId,
            Name = user.Name,
            Username = user.Username,
            Email = user.Email,
        };
    }

    public static CreateUserDto ToDto(CreateUserRequestModel user)
    {
        return new CreateUserDto
        {
            Name = user.Name,
            Username = user.Username,
            Email = user.Email,
            Password = user.Password,
        };
    }
}
