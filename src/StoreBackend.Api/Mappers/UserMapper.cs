using System;
using StoreBackend.Api.Models.Requests.user;
using StoreBackend.Api.Models.Responses.user;
using StoreBackend.Dto.user;

namespace StoreBackend.Api.Mappers;

public class UserMapper
{
    public static UserDto ToDto(CreateUserRequestModel model)
    {
        return new UserDto
        {
            ExternalId = model.ExternalId,
            Username = model.Username,
            Email = model.Email,
            Passwordhash = model.Passwordhash,
        };
    }

    public static List<UserResponseModel> ToModel(List<UserDto> users)
    {
        return users.Select(p => ToModel(p)).ToList();
    }

    public static UserResponseModel ToModel(UserDto user)
    {
        return new UserResponseModel
        {
            ExternalId = user.ExternalId,
            Username = user.Username,
            Email = user.Email,
            Passwordhash = user.Passwordhash,
        };
    }
}
