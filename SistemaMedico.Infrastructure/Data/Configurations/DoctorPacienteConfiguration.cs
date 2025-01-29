using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMedico.Core.Entities;

namespace SistemaMedico.Infrastructure.Data.Configurations
{
    public class DoctorPacienteConfiguration : IEntityTypeConfiguration<DoctorPaciente>
    {
        public void Configure(EntityTypeBuilder<DoctorPaciente> builder)
        {
            builder.ToTable("DoctorPaciente");

            builder.HasKey(dp => new { dp.DoctorId, dp.PacienteId });

            builder.HasOne(dp => dp.Doctor)
                .WithMany(d => d.DoctorPacientes)
                .HasForeignKey(dp => dp.DoctorId);

            builder.HasOne(dp => dp.Paciente)
                .WithMany(p => p.DoctorPacientes)
                .HasForeignKey(dp => dp.PacienteId);
        }
    }
}
