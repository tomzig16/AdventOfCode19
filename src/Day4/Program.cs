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

            Console.WriteLine("Part 2");
            nOfPossiblePasswords = 0;
            for (int i = inputLowest; i < inputHighest; i++)
            {
                if (IsAccordingToRulesPart2(i)) nOfPossiblePasswords++;
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

        static bool IsAccordingToRulesPart2(int number)
        {
            int[] digits = ToDigitArray(number);

            bool hasPair = false;

            for(int i = 1; i < digits.Length; i++)
            {
                if (digits[i - 1] > digits[i])
                {
                    // Number decreased
                    return false;
                }
            }

            for (int i = 1; i < digits.Length; i++)
            {
                if (digits[i] == digits[i - 1])
                {
                    if (i != digits.Length - 1)
                    {
                        int nOfSameNumbers = 1; // 1 for i - 1
                        for (int j = i; digits[j] == digits[i]; j++)
                        {
                            nOfSameNumbers++;
                            if (j == digits.Length - 1) break;
                        }
                        if(nOfSameNumbers == 2)
                        {
                            hasPair = true;
                        }
                        i += nOfSameNumbers - 2;
                    }
                    else
                    {
                        hasPair = true;
                    }
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
