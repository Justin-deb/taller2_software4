using Microsoft.EntityFrameworkCore;
using StoreBackend.DomainService.product;
using StoreBackend.DomainService.user;
using StoreBackend.Facade.product;
using StoreBackend.Facade.user;
using StoreBackend.Infrastructure.Repositories;
using StoreBackend.Infrastructure.Repositories.product;
using StoreBackend.Infrastructure.Repositories.user;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt => 
        opt.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();

builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IUserService,UserService>();

builder.Services.AddScoped<IProductFacade,ProductFacade>();
builder.Services.AddScoped<IUserFacade,UserFacade>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
