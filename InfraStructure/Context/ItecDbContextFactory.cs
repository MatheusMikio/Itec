using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace InfraStructure.Context
{
    public class ItecDbContextFactory : IDesignTimeDbContextFactory<ItecDbContext>
    {
        public ItecDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Itec");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("Itec") ?? configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ItecDbContext>();
            
            if (!string.IsNullOrWhiteSpace(connectionString)) optionsBuilder.UseNpgsql(connectionString);

            return new ItecDbContext(optionsBuilder.Options);
        }
    }
}
