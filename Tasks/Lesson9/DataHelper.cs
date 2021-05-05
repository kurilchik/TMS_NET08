using System;
using System.Collections.Generic;
using System.IO;

namespace Tasks.Lesson9
{
    public static class DataHelper
    {
        private const string PATH = @".\TikTok\";

        private static readonly string _userPath = $"{PATH}users.txt";
        private static readonly string _videoPath = $"{PATH}videos.txt";

        static DataHelper()
        {
            CheckFolder();
        }

        public static void AppendUser(User user)
        {
            File.AppendAllText(_userPath, $"{user.Id};{user.Date}\n");
        }

        public static List<User> ListUsers()
        {
            List<User> users = new List<User>();

            using (StreamReader sr = new StreamReader(_userPath))
            {
                string value = string.Empty;
                while (!string.IsNullOrWhiteSpace(value = sr.ReadLine()))
                {
                    string[] user = value.Split(";");
                    users.Add(new User(Guid.Parse(user[0]), DateTime.Parse(user[1])));
                }
            }
            return users;
        }

        public static void AppendVidoe(Video video)
        {
            File.AppendAllText(_videoPath, $"{video.Id};{video.UserId};{video.Date}\n");
        }

        public static List<Video> ListVideos()
        {
            List<Video> videos = new List<Video>();

            using (StreamReader sr = new StreamReader(_videoPath))
            {
                string value = string.Empty;
                while (!string.IsNullOrWhiteSpace(value = sr.ReadLine()))
                {
                    string[] video = value.Split(";");
                    videos.Add(new Video(Guid.Parse(video[0]), Guid.Parse(video[1]), DateTime.Parse(video[2])));
                }
            }
            return videos;
        }

        private static void CheckFolder()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(PATH);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }
    }
}
