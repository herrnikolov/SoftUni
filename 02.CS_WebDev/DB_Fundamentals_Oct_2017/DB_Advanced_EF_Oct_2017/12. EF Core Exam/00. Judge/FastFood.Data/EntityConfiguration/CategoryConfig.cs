namespace FastFood.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using FastFood.Models;

    class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);

            //my mistake
            builder.HasMany(e => e.Items)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId);

            builder.Property(c => c.Name).IsRequired();
        }
    }
}
