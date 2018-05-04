using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetClinic.Models;

namespace PetClinic.Data.EntityConfigs
{
    class ProcedureAnimalAidConfig :IEntityTypeConfiguration<ProcedureAnimalAid>
    {
        public void Configure(EntityTypeBuilder<ProcedureAnimalAid> builder)
        {
            builder.HasKey(e => new {e.ProcedureId, e.AnimalAidId});

            builder.HasOne(e => e.Procedure)
                .WithMany(o => o.ProcedureAnimalAids)
                .HasForeignKey(e => e.ProcedureId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.AnimalAid)
                .WithMany(o => o.AnimalAidProcedures)
                .HasForeignKey(e => e.AnimalAidId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //throw new NotImplementedException();
        }
    }
}
