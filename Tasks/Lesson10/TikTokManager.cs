using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Lesson10
{
    public class TikTokManager
    {
        private readonly DbContext _context;

        public TikTokManager(DbContext context)
        {
            _context = context;
        }

        public Guid AddUser()
        {
            var user = new User();
            var createdUser = _context.Set<User>().Add(user);
            _context.SaveChanges();

            return createdUser.Entity.Id;
        }

        public List<User> AllUsers()
        {
            return _context.Set<User>().ToList();
        }

        public Guid AddVideo(Guid userId)
        {
            var video = new UserVideos();
            video.UserId = userId;
            var createdVideo = _context.Set<UserVideos>().Add(video);
            _context.SaveChanges();

            return createdVideo.Entity.Id;
        }

        public User FindUser(Guid id)
        {
            return _context.Set<User>().SingleOrDefault(x => x.Id == id);
        }

        public UserVideos FindVideo(Guid id)
        {
            return _context.Set<UserVideos>().SingleOrDefault(x => x.Id == id);
        }

        public void RemoveUser(Guid id)
        {
            var user = _context.Set<User>().SingleOrDefault(x => x.Id == id);
            _context.Set<User>().Remove(user);
            _context.SaveChanges();
        }
    }
}
