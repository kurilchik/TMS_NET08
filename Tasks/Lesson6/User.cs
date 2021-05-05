using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Lesson6
{
    public class User
    {
        public readonly DateTime _createdAt;
        public string Name { get; set; }
        public int Age { get; set; }
        public UserStatus Status { get; private set; }

        public User()
        {
            Status = UserStatus.Created;
            _createdAt = DateTime.UtcNow;

        }
        public void UpdatedUserStatus(UserStatus status)
        {
            Status = status;
        }

        public string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
