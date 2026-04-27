using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto.product;

namespace StoreBackend.Facade.product;

public interface IProductFacade
{
    Task<List<ProductDto>> GetAllAsync();
    Task<ProductDto> GetByIdAsync(Guid productId);
    Task<ProductDto> AddAsync(ProductDto product);
    Task DeleteAsync(Guid productId);
}
