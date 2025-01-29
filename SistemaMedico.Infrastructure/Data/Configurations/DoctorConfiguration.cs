using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMedico.Core.Entities;

namespace SistemaMedico.Infrastructure.Data.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctor");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.ApellidoP)
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.ApellidoM)
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasMany(d => d.DoctorPacientes)
                .WithOne(dp => dp.Doctor)
                .HasForeignKey(dp => dp.DoctorId);
        }
    }
}
