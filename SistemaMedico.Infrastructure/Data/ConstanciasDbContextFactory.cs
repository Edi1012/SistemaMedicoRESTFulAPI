using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SistemaMedico.Infrastructure.Data
{
    public class ConstanciasDbContextFactory : IDesignTimeDbContextFactory<SistemaMedicoContext>
    {
        public IConfiguration Configuration { get; }
        public SistemaMedicoContext CreateDbContext(string[] args)
        {
            var pathConnection = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile(pathConnection, false);
            var fileConfiguration = configBuilder.Build();
           
            var optionsBuilder = new DbContextOptionsBuilder<SistemaMedicoContext>();
            optionsBuilder.UseSqlServer(fileConfiguration.GetConnectionString("DevConnection"));
                    
            return new SistemaMedicoContext(optionsBuilder.Options);
        }
    }
}