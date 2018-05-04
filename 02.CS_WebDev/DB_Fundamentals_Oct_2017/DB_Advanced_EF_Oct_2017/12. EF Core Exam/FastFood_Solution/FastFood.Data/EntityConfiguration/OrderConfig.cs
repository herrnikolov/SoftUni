namespace FastFood.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using FastFood.Models;
    class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.DateTime)
                .IsRequired();

            builder.Property(e => e.Type)
                .IsRequired();

            builder.HasOne(e => e.Employee)
                .WithMany(em => em.Orders)
                .HasForeignKey(e => e.EmployeeId);
        }
    }
}
