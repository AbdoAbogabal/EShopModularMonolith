namespace Catelog.Data;

public class CatelogDbContext : DbContext
{
    public CatelogDbContext(DbContextOptions<CatelogDbContext> options)
           : base(options) { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("Catelog");

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
