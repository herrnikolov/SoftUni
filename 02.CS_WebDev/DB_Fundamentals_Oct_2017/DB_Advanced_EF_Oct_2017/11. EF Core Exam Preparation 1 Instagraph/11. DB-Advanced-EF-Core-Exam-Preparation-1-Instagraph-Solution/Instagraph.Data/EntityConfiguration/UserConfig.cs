namespace Instagraph.Data.EntityConfiguration
{
    using Instagraph.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            //Unique
            builder.HasAlternateKey(e => e.Username);

            builder.Property(e => e.Username)
                .HasMaxLength(30);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(20);

            //One to Many, with One from User Side
            builder.HasOne(e => e.ProfilePicture)
                .WithMany(p => p.Users)
                .HasForeignKey(e => e.ProfilePictureId);
        }
    }
}
