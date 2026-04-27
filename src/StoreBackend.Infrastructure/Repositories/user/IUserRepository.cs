using System;
using StoreBackend.Domain.Entities;

namespace StoreBackend.Infrastructure.Repositories.user;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid userId);
    Task<User> AddAsync(User user);
    Task DeleteAsync(User user);
}
