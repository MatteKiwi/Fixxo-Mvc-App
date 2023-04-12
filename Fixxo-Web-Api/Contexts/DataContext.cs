using Fixxo_Web_Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fixxo_Web_Api.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<ProductEntity> Products { get; set; }
}