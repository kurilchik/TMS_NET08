using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Lesson4
{
    public class Algorythm
    {
        private const int NameLengthLimit = 128;

        private const int UpperCaseStartIndex = (int)'А';
        private const int UpperCaseEndIndex = (int)'Я';

        private const int LowerCaseStartIndex = (int)'а';
        private const int LowerCaseEndIndex = (int)'я';

        public void Execute()
        {
            do
            {
                var nameSymbolValues = new int[NameLengthLimit];
                var index = 0;
                for (; index < NameLengthLimit; index++)
                {
                    var value = Console.ReadKey();
                    if (value.Key == ConsoleKey.Enter)
                    {
                        break;
                    }

                    nameSymbolValues[index] = (int)value.KeyChar;
                }

                var result = ValidateName(nameSymbolValues, index);
                Console.WriteLine($"\n{result}");
            } while (true);
        }

        private bool ValidateName(int[] values, int length)
        {
            var isFirstLetter = true;

            for (var i = 0; i < length; i++)
            {
                if (isFirstLetter && values[i] != (int)ConsoleKey.Spacebar
                                  && (values[i] < UpperCaseStartIndex
                                      || values[i] > UpperCaseEndIndex))
                {
                    return false;
                }
                else if (!isFirstLetter && values[i] != (int)ConsoleKey.Spacebar
                                        && (values[i] < LowerCaseStartIndex
                                            || values[i] > LowerCaseEndIndex))
                {
                    return false;
                }
                else if (values[i] == (int)ConsoleKey.Spacebar)
                {
                    isFirstLetter = true;
                    continue;
                }

                isFirstLetter = false;
            }

            return true;
        }
    }
}
