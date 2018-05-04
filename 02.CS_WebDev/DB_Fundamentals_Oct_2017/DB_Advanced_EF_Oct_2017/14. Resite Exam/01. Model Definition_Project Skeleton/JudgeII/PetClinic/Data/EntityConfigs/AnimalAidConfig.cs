using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetClinic.Models;

namespace PetClinic.Data.EntityConfigs
{
    class AnimalAidConfig :IEntityTypeConfiguration<AnimalAid>
    {
        public void Configure(EntityTypeBuilder<AnimalAid> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(3)
                .HasMaxLength(30)
                .IsRequired();

            //builder.HasAlternateKey(e => e.Name);

            //throw new NotImplementedException();
        }
    }
}
