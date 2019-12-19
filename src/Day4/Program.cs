using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLowest = 372304;
            inputLowest = 377777;
            int inputHighest = 847060;

            int nOfPossiblePasswords = 0;
            for(int i = inputLowest; i < inputHighest; i++)
            {
                if (IsAccordingToRules(i)) nOfPossiblePasswords++;
            }
            Console.WriteLine($"Result: {nOfPossiblePasswords}");
            Console.ReadKey();
        }

        static bool IsAccordingToRules(int number)
        {
            int[] digits = ToDigitArray(number);

            bool hasPair = false;

            for (int i = 1; i < digits.Length; i++)
            {
                if(digits[i-1] > digits[i])
                {
                    // Number decreased
                    return false;
                }
                if((!hasPair) && 
                    (digits[i] == digits[i - 1]))
                {
                    hasPair = true;
                }
            }
            return hasPair;
        }

        static int[] ToDigitArray(int number)
        {
            // we know that the number is 6 digit
            int[] result = new int[6];
            for(int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = number % 10;
                number = number / 10;
            }
            return result;
        }
    }
}
