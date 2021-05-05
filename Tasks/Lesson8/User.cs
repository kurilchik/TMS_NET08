using System;
using System.Collections.Generic;

namespace Tasks.Lesson8
{
    public class User
    {
        public double Balance { get; set; } = 0;
        public Guid Id { get; set; }
        public List<double> Tratransactions { get; set; }
    }
}
