using System;

namespace Tasks.HW6
{
    public class GeneralElectric : IBitable
    {
        public void AnalyzeBite(string phrase)
        {
            char[] value = phrase.ToCharArray();

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] >= 'A' && value[i] <= 'Z')
                {
                    value[i] = (char)(value[i] + 32);
                }
            }

            Console.WriteLine(new string(value));
        }
    }
}
