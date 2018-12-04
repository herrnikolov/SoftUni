using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetClinic.Models;

namespace PetClinic.Data.EntityConfigs
{
    class AnimalConfig :IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(3)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.Type)
                .HasMaxLength(3)
                .HasMaxLength(20)
                .IsRequired();

            //My Mistate
            builder.HasOne(x => x.Passport)
                .WithOne(x => x.Animal)
                .HasForeignKey<Animal>(x => x.PassportSerialNumber);
        }
    }
}
