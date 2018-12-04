namespace Instagraph.Data.EntityConfiguration
{
    using Instagraph.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        //Add public
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Path)
               .IsRequired();

            //Users Collection from Photos
            //Posts Collection in Posts
        }
    }
}
