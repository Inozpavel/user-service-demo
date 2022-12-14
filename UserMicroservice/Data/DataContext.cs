using Microsoft.EntityFrameworkCore;

namespace UserMicroservice.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
