namespace FastFood.Data.EntityConfiguration
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(30)
                .IsRequired();
            
            //my mistake

            builder.HasMany(e => e.Employees)
                .WithOne(e => e.Position)
                .HasForeignKey(e => e.PositionId);

            builder.HasAlternateKey(e => e.Name);
        }
    }
}
