using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasks.Lesson8
{
    public class Run
    {
        public void Program()
        {
            MTS mts = new MTS();
            Random random = new Random();

            var bankUsers = Enumerable.Range(1, 5)
                .Select(x => new User
                {
                    Id = Guid.NewGuid(),
                    Tratransactions = Enumerable.Range(1, 10)
                    .Select(x => (double)random.Next(-1000, 1000))
                    .ToList()
                }).ToList();
        }
    }
}
