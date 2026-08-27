using BLL;
using BLL.Services;
using DAL.EF;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<CollectRequestRepo>();
builder.Services.AddScoped<DistributionRepo>();
builder.Services.AddScoped<EmployeeRepo>();
builder.Services.AddScoped<RestaurantRepo>();
builder.Services.AddScoped<FoodItemRepo>();
builder.Services.AddScoped<CollectRequestService>();
builder.Services.AddScoped<DistributionService>();
builder.Services.AddScoped<RestaurantService>();
builder.Services.AddScoped<FoodItemService>();
builder.Services.AddScoped<EmployeeService>();

builder.Services.AddDbContext<ZeroHungerDbContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});

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
