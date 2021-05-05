using System;

namespace Tasks.Lesson10
{
    public class UserVideos
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreateAt { get; set; }

        public User User { get; set; }

        public UserVideos()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
