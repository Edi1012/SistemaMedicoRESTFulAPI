using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaMedico.Core.Entities;
using SistemaMedico.Infrastructure.Data.Configurations;

#nullable disable

namespace SistemaMedico.Infrastructure.Data
{
    public partial class SistemaMedicoContext : DbContext
    {
        public SistemaMedicoContext()
        {
        }

        public SistemaMedicoContext(DbContextOptions<SistemaMedicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Paciente> Pacientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PacienteConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
