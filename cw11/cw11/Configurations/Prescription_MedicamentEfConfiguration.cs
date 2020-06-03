using cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Configurations
{
    public class Prescription_MedicamentEfConfiguration : IEntityTypeConfiguration<Prescription_Medicament>
    {
        public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
        {
            builder.HasKey(e => new { e.IdMedicament, e.IdPrescription});

            builder.Property(e => e.Dose)
                    .IsRequired();
            builder.Property(e => e.Details)
                    .HasMaxLength(100)
                    .IsRequired();
        }
    }
}
