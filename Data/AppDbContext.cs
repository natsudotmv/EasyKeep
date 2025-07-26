using EasyKeep.Models;
using Microsoft.EntityFrameworkCore;
namespace EasyKeep.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Accessory> Accessories { get; set; }
}