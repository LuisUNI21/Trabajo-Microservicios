using Microsoft.EntityFrameworkCore;
using Operations.Data;
using Operations.Middleware;
using AppCore.Security;
using Operations.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var builder=WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddDbContext<AppDbContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app=builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<CustomAuthMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();