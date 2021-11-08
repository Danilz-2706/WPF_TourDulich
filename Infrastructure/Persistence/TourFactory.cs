using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.Persistence
{
    public class TourFactory : IDesignTimeDbContextFactory<TourContext>
    {
        public TourContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuration.GetConnectionString("TourDB");
            var optionsBuilder = new DbContextOptionsBuilder<TourContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new TourContext(optionsBuilder.Options);
        }
    }
}