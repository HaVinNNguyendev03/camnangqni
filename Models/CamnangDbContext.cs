using Microsoft.EntityFrameworkCore;

public class CamnangDbContext : DbContext
{
    public CamnangDbContext(DbContextOptions<CamnangDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Users> Users { get; set; } // Thêm DbSet cho Users
    
}