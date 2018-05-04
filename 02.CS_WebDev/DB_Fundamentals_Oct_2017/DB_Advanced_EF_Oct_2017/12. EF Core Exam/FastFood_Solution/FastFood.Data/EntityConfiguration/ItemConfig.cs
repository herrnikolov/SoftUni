namespace FastFood.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using FastFood.Models;
    class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Category)
                .WithMany(p => p.Items)
                .HasForeignKey(e => e.CategoryId);

            builder.Property(e => e.Name)
                .HasMaxLength(3)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.Price)
                 .IsRequired();

            //my mistake - for uniqueness 
            builder.HasAlternateKey(e => e.Name);
        }
    }
}
