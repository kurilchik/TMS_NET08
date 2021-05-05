using System;
using System.IO;

namespace Tasks.Lesson7_1
{
    public class Bank
    {
        private const double RATE = 1.20;
        private const string PATH = @".\Users\";

        private readonly string _filePath = $"{PATH}Users.CSV";

        public Bank()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(PATH);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }

        public void GiveLoan(User user, double amount)
        {
            var total = -1 * amount * RATE;
            UpdateBalance(user, total);
        }
        public void TopUpBalance(User user, double amount)
        {
            UpdateBalance(user, amount);
        }
        public void GetBalance(User user)
        {
            string[] transactions = ReadData();

            Console.WriteLine($"User ID: {user.Id}.");
            Console.WriteLine("List of transactions:");
            foreach (var item in transactions)
            {
                string[] transaction = item.Split(":");
                if (int.Parse(transaction[0]) == user.Id)
                {
                    Console.WriteLine(transaction[1]);
                }
            }
            Console.WriteLine($"Total balance: {user.Balance}");
            Console.WriteLine(Environment.NewLine);
        }
        public void GetBalanceSR(User user)
        {
            using (StreamReader sr = new StreamReader(_filePath))
            {
                Console.WriteLine($"User ID: {user.Id}.");
                Console.WriteLine("List of transactions:");
                string value;
                while (!string.IsNullOrWhiteSpace(value = sr.ReadLine()))
                {
                    string[] transaction = value.Split(":");
                    if (int.Parse(transaction[0]) == user.Id)
                    {
                        Console.WriteLine(transaction[1]);
                    }
                }
                Console.WriteLine($"Total balance: {user.Balance}");
            }
        }
        private void UpdateBalance(User user, double amount)
        {
            user.Balance += amount;
            LogDate(user, amount);
        }
        private void LogDate(User user, double amount)
        {
            File.AppendAllText(_filePath, $"{user.Id}:{amount}\n");
        }

        private string[] ReadData()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}
