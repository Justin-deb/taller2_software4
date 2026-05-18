using StoreBackend.Api.Enumerations;

namespace StoreBackend.Api.Models.Responses.user;

public class UserRolesResponseModel
{
    public List<RoleAliases> Roles { get; set; } = [];
}