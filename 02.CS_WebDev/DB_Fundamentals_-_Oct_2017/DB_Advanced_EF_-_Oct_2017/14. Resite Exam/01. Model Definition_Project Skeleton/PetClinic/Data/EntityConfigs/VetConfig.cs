using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetClinic.Models;

namespace PetClinic.Data.EntityConfigs
{
    class VetConfig :IEntityTypeConfiguration<Vet>
    {
        public void Configure(EntityTypeBuilder<Vet> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(3)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(e => e.Profession)
                .HasMaxLength(3)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Age)
                .HasMaxLength(22)
                .HasMaxLength(65)
                .IsRequired();

            builder.HasAlternateKey(e => e.PhoneNumber);

            builder.Property(e => e.PhoneNumber)
                .IsUnicode(false)
                .HasColumnType("CHAR(10)")
                .IsRequired();
            //throw new NotImplementedException();
        }
    }
}
