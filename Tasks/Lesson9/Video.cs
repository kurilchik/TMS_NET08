using System;

namespace Tasks.Lesson9
{
    public class Video
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }

        public Video(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Date = DateTime.UtcNow;
        }

        public Video(Guid id, Guid userId, DateTime date)
        {
            Id = id;
            UserId = userId;
            Date = date;
        }
    }
}
