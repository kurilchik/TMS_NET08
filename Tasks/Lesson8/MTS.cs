using System;
using System.Linq;

namespace Tasks.Lesson8
{
    public class MTS : OpSoS
    {
        public void TopUp(User user, double amount)
        {
            UpdateBalance(user, amount);
        }
        public void Withdraw(User user, double amount)
        {
            UpdateBalance(user, amount * -1);
        }
        public void GetBalance(User user)
        {

            var transactions = FindUserData(user).ToArray();

            Console.WriteLine($"User ID: {user.Id}.");
            Console.WriteLine("List of transactions:");
            foreach (var item in transactions)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total balance: {TotalBalance(transactions)} BYN.");
            Console.WriteLine(Environment.NewLine);
        }

        private void UpdateBalance(User user, double amount)
        {
            user.Balance += amount;
            WriteData(user, amount);
        }
        private double TotalBalance(double[] transactions)
        {
            double sum = default;
            foreach (var item in transactions)
            {
                sum += item;
            }
            return sum;
        }
    }
}
