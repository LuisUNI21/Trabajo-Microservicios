using Microsoft.EntityFrameworkCore;
using AppCore.Models;
namespace Operations.Data{
public class AppDbContext:DbContext{
 public AppDbContext(DbContextOptions<AppDbContext> o):base(o){}
 public DbSet<Usuario> Usuarios{get;set;}
}}