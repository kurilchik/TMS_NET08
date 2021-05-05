using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Tasks.Lesson10
{
    public class TikTokDesignTimeFactory : IDesignTimeDbContextFactory<TikTokDbContext>
    {
        public TikTokDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = config.GetValue<string>("database");

            var optionsBuilder = new DbContextOptionsBuilder<TikTokDbContext>();
            optionsBuilder.UseSqlServer(connectionString,
                y => y.MigrationsHistoryTable("andrew.kurilchik@gmail.com_migrations", "andrew.kurilchik@gmail.com"));

            return new TikTokDbContext(optionsBuilder.Options);
        }
    }
}
