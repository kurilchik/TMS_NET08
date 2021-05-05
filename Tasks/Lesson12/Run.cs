using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks.Lesson12
{
    public class Run
    {
        // dotnet ef migrations add Abc_migration --context AbcDbContext --startup-project Sample --project Tasks --verbose
        // dotnet ef database update --context AbcDbContext --startup-project Sample --project Tasks --verbose

        public void Program()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            string connectionString = config.GetValue<string>("database");

            ServiceProvider services = new ServiceCollection()
                .AddDbContext<DbContext, AbcDbContext>(x => x.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("andrew.kurilchik@gmail.com_migrations", "andrew.kurilchik@gmail.com")))
                .AddTransient<AbcManager>()
                .BuildServiceProvider();


            AbcManager manager = services.GetService<AbcManager>();

            Random random = new Random();
            DateTime dateStart = new DateTime(2021, 1, 1);

            List<A> a = Enumerable.Range(1, 1000).Select(x => new A()
            {
                Value = random.Next(-100, 100),
                Date = dateStart.AddDays(random.Next(30))
            }).ToList();

            foreach (var item in a)
            {
                item.Id = manager.AddA(item);
            }

            List<B> b = Enumerable.Range(1, 1000).Select(x => new B() { Date = dateStart.AddDays(random.Next(30)) }).ToList();

            foreach (var item in b)
            {
                item.Id = manager.AddB(item);
            }
        }
    }
}
