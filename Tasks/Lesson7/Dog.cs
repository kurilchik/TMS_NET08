using System;
using System.IO;
using System.Text;

namespace Tasks.Lesson7
{
    public class Dog
    {
        private readonly string _path = @"C:\temp\Dog.txt";

        public Dog()
        {
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }            
        }

        public void Bark()
        {
            using (var stream = File.OpenWrite(_path))
            {
                var date = default(string);
                while (!string.IsNullOrWhiteSpace(date = Console.ReadLine()))
                {
                    var dataBytes = Encoding.UTF8.GetBytes($"{date}\n");
                    stream.Write(dataBytes, 0, dataBytes.Length);
                }                
            }
        }

        public void Bark(string date)
        {
            File.AppendAllText(_path, $"{date}\n");
        }
    }
}
