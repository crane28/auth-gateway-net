using AuthGateway.Domain.Interfaces.Repositories;
using AuthGateway.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AuthGatewayContext>(o => 
    o.UseNpgsql(builder.Configuration.GetConnectionString("NeonPostgreSQL"))
);

builder.Services.AddScoped<IUserRepository>();

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
