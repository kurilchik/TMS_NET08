using System;

namespace Tasks.HW6
{
    public class Dog
    {
        private readonly string _phrase = "Wof-Wof";
        public DogType DogType { get; private set; }

        public Dog(DogType dogType)
        {
            DogType = dogType;
        }

        public void Bite()
        {
            Console.WriteLine(_phrase);
        }

        public void Bite(IBitable mode)
        {
            mode.AnalyzeBite(_phrase);
        }
    }
}
