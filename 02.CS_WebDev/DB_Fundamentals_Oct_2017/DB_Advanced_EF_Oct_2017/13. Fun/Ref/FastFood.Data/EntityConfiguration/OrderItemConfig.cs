namespace FastFood.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using FastFood.Models;
    class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(e => new { e.OrderId, e.ItemId });

            // my mistake
            builder.HasOne(e => e.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(e => e.OrderId);

            builder.HasOne(e => e.Item)
                .WithMany(i => i.OrderItems)
                .HasForeignKey(e => e.OrderId);

            //builder.Property(e => e.Order)
            //    .IsRequired();

            //builder.Property(e => e.Item)
            //    .IsRequired();

            //builder.Property(e => e.Quantity)
            //    .IsRequired();
        }
    }
}
