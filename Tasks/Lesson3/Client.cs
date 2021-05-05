using System;

namespace Tasks.Lesson3
{
    public class Client : IClient
    {
        private readonly AgeManager _ageMngr;

        private readonly ILogger _logger;

        private readonly IReader _reader;

        public Client(ILogger logger, IReader reader)
        {
            _ageMngr = new AgeManager();
            _logger = logger;
            _reader = reader;
            InitializeData();
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public int Age { get; private set; }

        public void PrintUserData()
        {
            _logger.PrintLine($"Person: {Name} {Surname}, age = {Age}");
        }



        private void InitializeData()
        {
            _logger.Print("Give the Name: ");
            Name = _reader.ReadLine();
            Console.Write("Give the Surname: ");
            Surname = Console.ReadLine();

            var tempAge = GetAge();
            if (!tempAge.HasValue)
            {
                throw new ArgumentNullException("Age is empty");
            }

            Age = tempAge.Value;
        }

        private int? GetAge()
        {
            Console.Write("Give the Age: ");
            return _ageMngr.ReadValue();
        }
    }
}
