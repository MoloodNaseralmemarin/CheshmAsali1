using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CheshmAsali.Domain.Data
{
    public class CheshmAsaliDbContextFactory : IDesignTimeDbContextFactory<CheshmAsaliDbContext>
    {
        public CheshmAsaliDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CheshmAsaliDbContext>();
            var connectionString = configuration.GetConnectionString("CheshmAsaliConnection");

            builder.UseSqlServer(connectionString);

            return new CheshmAsaliDbContext(builder.Options);
        }
    }
}
