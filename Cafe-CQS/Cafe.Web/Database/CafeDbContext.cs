using Cafe.Web.Model;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Web.Database;

public class CafeDbContext : DbContext
{
    public CafeDbContext(DbContextOptions<CafeDbContext> options) : base(options)
    {
        
    }

    public DbSet<Dishes> Dishes { get; set; }
}