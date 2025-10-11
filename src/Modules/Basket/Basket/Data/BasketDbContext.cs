namespace Basket.Data;

public class BasketDbContext : DbContext
{
    public BasketDbContext(DbContextOptions<BasketDbContext> options)
        : base(options) { }

    public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();
    public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();
    public DbSet<ShoppingCartItem> ShoppingCartItems => Set<ShoppingCartItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("Basket");

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

}
