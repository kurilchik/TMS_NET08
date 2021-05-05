using System;
using System.Collections.Generic;

namespace Tasks.HW11
{
    public class User
    {
        public Guid Id { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
