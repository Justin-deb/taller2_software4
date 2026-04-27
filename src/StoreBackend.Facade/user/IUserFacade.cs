using System;
using StoreBackend.Dto.user;

namespace StoreBackend.Facade.user;

public interface IUserFacade
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(Guid userId);
    Task<UserDto> AddAsync(UserDto user);
    Task DeleteAsync(Guid userId);
}
