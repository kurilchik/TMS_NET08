using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Tasks.Lesson10
{
    public class Run
    {
        // dotnet ef migrations add TikTok_migration --context TikTokDbContext --startup-project Sample --project Tasks --verbose
        // dotnet ef database update --context TikTokDbContext --startup-project Sample --project Tasks --verbose

        public void Program()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = config.GetValue<string>("database");

            var services = new ServiceCollection()
                .AddDbContext<DbContext, TikTokDbContext>(x => x.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("andrew.kurilchik@gmail.com_migrations", "andrew.kurilchik@gmail.com")))
                .AddTransient<TikTokManager>()
                .BuildServiceProvider();

            var manager = services.GetService<TikTokManager>();


            var userId = manager.AddUser();
            var user = manager.FindUser(userId);
            Console.WriteLine($"UserID: {user.Id}. Create at {user.CreateAt}");

            var userId2 = manager.AddUser();
            var user2 = manager.FindUser(userId2);
            Console.WriteLine($"UserID: {user2.Id}. Create at {user.CreateAt}");

            var videoId = manager.AddVideo(user.Id);
            var userVideo = manager.FindVideo(videoId);
            Console.WriteLine($"VideoID: {userVideo.Id}. Create at {userVideo.CreateAt} (UserID: {userVideo.UserId})");

            var videoId2 = manager.AddVideo(user2.Id);
            var userVideo2 = manager.FindVideo(videoId2);
            Console.WriteLine($"VideoID: {userVideo2.Id}. Create at {userVideo2.CreateAt} (UserID: {userVideo2.UserId})");

            var users = manager.AllUsers();
                foreach (var item in users)
                {
                    Console.WriteLine(item.Id);
                }

        }
    }
}
