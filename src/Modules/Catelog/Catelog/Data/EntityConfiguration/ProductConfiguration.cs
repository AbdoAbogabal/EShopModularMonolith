namespace Catelog.Data.EntityConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Price).IsRequired();
        builder.Property(e => e.Categories).IsRequired();

        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);

        builder.Property(e => e.ImageFile).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(200);
    }
}
