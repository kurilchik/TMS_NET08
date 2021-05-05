using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tasks.Lesson12
{
    public class AbcDesignTimeFactory : IDesignTimeDbContextFactory<AbcDbContext>
    {
        public AbcDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = config.GetValue<string>("database");

            var optionsBuilder = new DbContextOptionsBuilder<AbcDbContext>();
            optionsBuilder.UseSqlServer(connectionString,
                y => y.MigrationsHistoryTable("andrew.kurilchik@gmail.com_migrations", "andrew.kurilchik@gmail.com"));

            return new AbcDbContext(optionsBuilder.Options);
        }
    }
}
