namespace Basket.Data.EntityConfiguration;

public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.ToTable("ShoppingCarts");

        builder.HasKey(e => e.Id);


        builder.HasIndex(e => e.UserName)
               .IsUnique();
        builder.Property(e => e.UserName)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasMany(e => e.Items).WithOne().HasForeignKey(e => e.ShoppingCartId).OnDelete(DeleteBehavior.Cascade);
    }
}
