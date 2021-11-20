using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMedico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedico.Infrastructure.Data.Configurations
{
    class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder) 
        {
           
                builder.ToTable("Paciente");
                
                builder.HasKey(e =>e.Id);
                
                builder.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Id");

                builder.Property(e => e.ApellidoM)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                builder.Property(e => e.ApellidoP)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                builder.Property(e => e.Nombres)
                    .HasMaxLength(150)
                    .IsUnicode(false);
        }
    }
}
