using System;

namespace Tasks.HW11
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
