using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto.product;

namespace StoreBackend.DomainService.product;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid productId);
    Task<Product> AddAsync(ProductDto product);
    Task DeleteAsync(Guid product);
}
