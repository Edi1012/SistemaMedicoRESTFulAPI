using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMedico.Core.Entities;

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
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd();

                builder.Property(e => e.ApellidoM)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                builder.Property(e => e.ApellidoP)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                builder.Property(e => e.Nombres)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                builder.HasMany(p => p.DoctorPacientes)
                    .WithOne(dp => dp.Paciente)
                    .HasForeignKey(dp => dp.PacienteId);
        }
    }
}
