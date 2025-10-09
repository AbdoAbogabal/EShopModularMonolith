namespace Ordering.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CustomerId);

        builder.HasIndex(e => e.OrderName).IsUnique();

        builder.Property(e => e.OrderName).IsRequired().HasMaxLength(100);

        builder.HasMany(e => e.Items).WithOne().HasForeignKey(e => e.OrderId).OnDelete(DeleteBehavior.Cascade);

        builder.ComplexProperty(o => o.ShippingAddress, addressBuilder =>
        {
            addressBuilder.Property(a => a.State).HasMaxLength(50);
            addressBuilder.Property(a => a.Country).HasMaxLength(50);
            addressBuilder.Property(a => a.ZipCode).HasMaxLength(50);
            addressBuilder.Property(a => a.EmailAddress).HasMaxLength(50);
            addressBuilder.Property(a => a.LastName).HasMaxLength(50).IsRequired();
            addressBuilder.Property(a => a.FirstName).HasMaxLength(50).IsRequired();
            addressBuilder.Property(a => a.AddressLine).HasMaxLength(180).IsRequired();
        });

        builder.ComplexProperty(o => o.BillingAddress, addressBuilder =>
        {
            addressBuilder.Property(a => a.State).HasMaxLength(50);
            addressBuilder.Property(a => a.Country).HasMaxLength(50);
            addressBuilder.Property(a => a.ZipCode).HasMaxLength(50);
            addressBuilder.Property(a => a.EmailAddress).HasMaxLength(50);
            addressBuilder.Property(a => a.LastName).HasMaxLength(50).IsRequired();
            addressBuilder.Property(a => a.FirstName).HasMaxLength(50).IsRequired();
            addressBuilder.Property(a => a.AddressLine).HasMaxLength(180).IsRequired();
        });

        builder.ComplexProperty(o => o.Payment, paymentBuilder =>
        {
            paymentBuilder.Property(a => a.PaymentMethod);
            paymentBuilder.Property(a => a.CVV).HasMaxLength(3);
            paymentBuilder.Property(a => a.CardName).HasMaxLength(50);
            paymentBuilder.Property(a => a.Expiration).HasMaxLength(10);
            paymentBuilder.Property(a => a.CardNumber).HasMaxLength(24).IsRequired();
        });
    }
}
