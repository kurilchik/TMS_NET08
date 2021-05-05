using System;

namespace Tasks.Lesson9
{
    public class TikTok
    {
        public void AddUser(User user)
        {
            DataHelper.AppendUser(user);
        }
        public Guid FindUser()
        {
            User[] users = DataHelper.ListUsers().ToArray();

            Console.WriteLine("List of users:");
            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].Id}");
            }
            Console.WriteLine($"Enter from 1 to {users.Length} to select a user:");
            int userInput = UserInput(users.Length);
            return users[userInput - 1].Id;
        }
        private int UserInput(int length)
        {
            if (int.TryParse(Console.ReadLine(), out int userInput) && userInput <= length)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("You entered incorrect data!");
                return UserInput(length);
            }
        }
    }
}
