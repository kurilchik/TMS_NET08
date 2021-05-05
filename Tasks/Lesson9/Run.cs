using System.Collections.Generic;
using System.Linq;

namespace Tasks.Lesson9
{
    public class Run
    {
        public void Program()
        {
            TikTok tikTok = new TikTok();

            List<User> users = Enumerable.Range(1, 10).Select(x => new User()).ToList();
            foreach (var user in users)
            {
                tikTok.AddUser(user);
                List<Video> videos = Enumerable.Range(1, 5).Select(x => new Video(user.Id)).ToList();
                foreach (var video in videos)
                {
                    user.AddVideo(video);
                }
            }

            User.GetUserVideos(tikTok.FindUser());
        }
    }
}
