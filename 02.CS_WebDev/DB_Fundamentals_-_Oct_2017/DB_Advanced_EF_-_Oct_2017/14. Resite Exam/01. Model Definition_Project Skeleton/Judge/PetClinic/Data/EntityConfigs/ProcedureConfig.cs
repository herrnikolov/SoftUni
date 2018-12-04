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
            //throw new NotImplementedException();
        }
    }
}
