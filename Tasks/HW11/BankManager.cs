using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.HW11
{
    public class BankManager
    {
        private readonly DbContext _context;

        public BankManager(DbContext context)
        {
            _context = context;
        }

        public Guid AddUser()
        {
            User user = new User();
            EntityEntry<User> createdUser = _context.Set<User>().Add(user);
            _context.SaveChanges();

            return createdUser.Entity.Id;
        }

        public void TopUpBalance(Guid userId, double amount)
        {
            AddTransaction(userId, amount);
        }

        public void GiveLoan(Guid userId, double rate, double amount)
        {
            double totalAmount = -1 * rate * amount;
            AddTransaction(userId, totalAmount);
        }

        public double GetBalance(Guid userId)
        {
            List<double> transactions = GetTransactions(userId).Select(x => x.Amount).ToList();
            return transactions.Sum();
        }

        public List<Transaction> GetTransactions(Guid userId)
        {
            return _context.Set<Transaction>().Where(x => x.UserId == userId).ToList();
        }

        private void AddTransaction(Guid userId, double amount)
        {
            Transaction transaction = new Transaction
            {
                UserId = userId,
                Amount = amount,
                Date = DateTime.UtcNow
            };
            _context.Set<Transaction>().Add(transaction);
            _context.SaveChanges();
        }
    }
}
