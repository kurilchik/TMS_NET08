using System;

namespace Tasks.Lesson3
{
    class AgeManager
    {
        public int? ReadValue()
        {
            int? age = default;
            for (var index = 0; index < 3; index++)
            {
                var ageRaw = Console.ReadLine();
                var ageParseSuccess = int.TryParse(ageRaw, out var innerAge);
                if (ageParseSuccess && innerAge >= 18)
                {
                    age = innerAge;
                    break;
                }

                Console.Write("Corrupted value or under age, try again: ");
            }

            return age;
        }
    }
}
