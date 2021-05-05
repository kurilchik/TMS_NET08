using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tasks.HW11
{
    public class BankingDesignTimeFactory : IDesignTimeDbContextFactory<BankDbContext>
    {
        public BankDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = config.GetValue<string>("database");

            var optionsBuilder = new DbContextOptionsBuilder<BankDbContext>();
            optionsBuilder.UseSqlServer(connectionString,
                y => y.MigrationsHistoryTable("andrew.kurilchik@gmail.com_migrations", "andrew.kurilchik@gmail.com"));

            return new BankDbContext(optionsBuilder.Options);
        }
    }
}
