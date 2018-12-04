using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetClinic.Models;

namespace PetClinic.Data.EntityConfigs
{
    class PassportConfig :IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.HasKey(e => e.SerialNumber);

            builder.Property(e => e.OwnerName)
                .HasMaxLength(3)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.RegistrationDate)
                .IsRequired();
            //throw new NotImplementedException();
        }
    }
}
