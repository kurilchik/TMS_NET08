using System.Collections.Generic;
using System.IO;

namespace Tasks.Lesson8
{
    public class OpSoS
    {
        private const string PATH = @".\OpSoS\";

        private readonly string _filePath = $"{PATH}Users.CSV";

        public OpSoS()
        {
            CheckFolder();
            CheckFile();
        }

        protected void WriteData(User user, double amount)
        {
            File.AppendAllText(_filePath, $"{user.Id}:{amount}\n");
        }
        protected List<double> FindUserData(User user)
        {
            List<double> userData = new List<double>();

            using (StreamReader sr = new StreamReader(_filePath))
            {
                string value = string.Empty;
                while (!string.IsNullOrWhiteSpace(value = sr.ReadLine()))
                {
                    string[] transaction = value.Split(":");
                    if (transaction[0] == user.Id.ToString())
                    {
                        if (double.TryParse(transaction[1], out double data))
                        {
                            userData.Add(data);
                        }
                        else
                        {
                            System.Console.WriteLine("Wrong data!");
                        }
                    }                   
                }
            }
            return userData;
        }

        private void CheckFolder()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(PATH);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }
        private void CheckFile()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
    }
}
