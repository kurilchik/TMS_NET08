using System;

namespace Tasks.Lesson7
{
    public class Run
    {
        public void Program()
        {
            Dog dog = new Dog();
            //dog.Bark();

            string date;
            while (!string.IsNullOrWhiteSpace(date = Console.ReadLine()))
            {
                dog.Bark(date);
            }
        }
    }
}
