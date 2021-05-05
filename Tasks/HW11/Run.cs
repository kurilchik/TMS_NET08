using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks.HW11
{
    public class Run
    {
        // dotnet ef migrations add Bank_migration --context BankDbContext --startup-project Sample --project Tasks --verbose
        // dotnet ef database update --context BankDbContext --startup-project Sample --project Tasks --verbose

        public void Program()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            string connectionString = config.GetValue<string>("database");

            ServiceProvider services = new ServiceCollection()
                .AddDbContext<DbContext, BankDbContext>(x => x.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("andrew.kurilchik@gmail.com_migrations", "andrew.kurilchik@gmail.com")))
                .AddTransient<BankManager>()
                .BuildServiceProvider();

            BankManager manager = services.GetService<BankManager>();

            Random random = new Random();

            List<double> rates = Enumerable.Range(2, 5).Select(x => (double)(x * 5)).ToList();

            List<User> users = Enumerable.Range(1, 3).Select(x => new User()).ToList();

            foreach (var user in users)
            {
                user.Id = manager.AddUser();
                List<Transaction> transactions = Enumerable.Range(1, 5).Select(x => new Transaction()).ToList();

                foreach (var transaction in transactions)
                {
                    foreach (var rate in rates)
                    {
                        manager.GiveLoan(user.Id, rate, (double)random.Next(100, 1000));
                    }

                    manager.TopUpBalance(user.Id, (double)random.Next(100, 1000));
                }
            }

            Console.WriteLine("Balance:");
            foreach (var user in users)
            {
                Console.WriteLine($"{manager.GetBalance(user.Id)} BYN (UserID:{user.Id}).");
            }
        }
    }
}
