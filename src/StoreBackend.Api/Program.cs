using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using StoreBackend.DomainService;
using StoreBackend.Facade;
using StoreBackend.Infrastructure;
using StoreBackend.Infrastructure.Repositories;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using StoreBackend.Api.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using StoreBackend.Api.Security;
using StoreBackend.Infrastructure.Repositories.product;
using StoreBackend.DomainService.product;
using StoreBackend.Facade.product;
using StoreBackend.Facade.user;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using System.Threading.RateLimiting;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<MessageExceptionFilter>();
})
 .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // enables passing enum values as strings to the API endpoints
    });

var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOriginsPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins!)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var jwtSettings = builder.Configuration.GetSection("Jwt");

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Secret"]))
        };
    });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();

// Facades
builder.Services.AddScoped<IProductFacade, ProductFacade>();
builder.Services.AddScoped<IUserFacade, UserFacade>();
builder.Services.AddScoped<IAuthorizationFacade, AuthorizationFacade>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AuthorizationPolicies.CanSearchUsers, policy =>
       policy.RequireRole(
           RoleNames.Administrator,
           RoleNames.Support
       ));
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var permitLimit = builder.Configuration.GetValue<int>("RateLimiting:PermitLimit");

var windowSeconds = builder.Configuration.GetValue<int>("RateLimiting:WindowSeconds");

var queueLimit = builder.Configuration.GetValue<int>("RateLimiting:QueueLimit");

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", limiterOptions =>
    {
        limiterOptions.PermitLimit = permitLimit;
        limiterOptions.Window = TimeSpan.FromSeconds(windowSeconds);
        limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        limiterOptions.QueueLimit = queueLimit;
    });
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.ContentType = "application/json";
        await context.HttpContext.Response.WriteAsync("""{ "Status": 429, "message": "Demasiadas solicitudes. Intente nuevamente mas tarde.""", cancellationToken: token);
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowedOriginsPolicy");

app.UseAuthentication();

app.UseRateLimiter();

app.UseAuthorization();

app.UseRateLimiter();



app.MapControllers().RequireRateLimiting("fixed");

app.Run();