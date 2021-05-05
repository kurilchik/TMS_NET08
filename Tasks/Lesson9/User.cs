using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Lesson9
{
    public class User
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
            Date = DateTime.UtcNow;
        }

        public User(Guid id, DateTime date)
        {
            Id = id;
            Date = date;
        }

        public void AddVideo(Video video)
        {
            DataHelper.AppendVidoe(video);
        }

        public static void GetUserVideos(Guid userId)
        {
            List<Video> userVideos = DataHelper.ListVideos().Where(video => video.UserId == userId).ToList();

            Console.WriteLine($"Video list (User ID<{userId}>:");
            foreach (var item in userVideos)
            {
                Console.WriteLine($"{item.Id} ({item.Date})");
            }
        }
    }
}
