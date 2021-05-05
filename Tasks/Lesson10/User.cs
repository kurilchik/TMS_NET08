using System;
using System.Collections.Generic;

namespace Tasks.Lesson10
{
    public class User
    {
        public Guid Id { get; set; }

        public DateTime CreateAt { get; set; }

        public List<UserVideos> Videos { get; set; }

        public User()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
