using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetClinic.Models;

namespace PetClinic.Data.EntityConfigs
{
    class ProcedureConfig :IEntityTypeConfiguration<Procedure>
    {
        public void Configure(EntityTypeBuilder<Procedure> builder)
        {
            builder.HasKey(e => e.Id);

            //My Mistake
            builder.HasOne(e => e.Vet)
                .WithMany(e => e.Procedures)
                .HasForeignKey(e => e.VetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Animal)
                .WithMany(e => e.Procedures)
                .HasForeignKey(e => e.AnimalId)
                .OnDelete(DeleteBehavior.Restrict);

            //throw new NotImplementedException();
        }
    }
}
