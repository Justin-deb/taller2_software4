using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto.user;

namespace StoreBackend.DomainService.user;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid userId);
    Task<User> AddAsync(CreateUserDto user);
    Task DeleteAsync(Guid user);
    Task<User> CreateAsync(CreateUserDto user);
}
