using System;
using StoreBackend.Domain.Entities;

namespace StoreBackend.Infrastructure.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> CreateAsync(User user);
    Task<User?> GetByIdAsync(Guid userId);
    Task<bool> HasUserByUsernameAsync(string username);
    Task<bool> HasUserByEmailAsync(string email);
    Task<User?> GetByUsername(string username);

}