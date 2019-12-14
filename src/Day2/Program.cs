using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entry = File.ReadAllLines("..\\..\\input\\input.txt", Encoding.UTF8)[0].Split(',');
            int[] elements = Array.ConvertAll(entry, e => int.Parse(e));

            elements[1] = 12;
            elements[2] = 2;

            for (int i = 0; elements[i] != 99; i += 4)
            {
                if (elements[i] == 1)
                {
                    elements[elements[i + 3]] = elements[elements[i + 1]] + elements[elements[i + 2]];
                }
                else if (elements[i] == 2)
                {
                    elements[elements[i + 3]] = elements[elements[i + 1]] * elements[elements[i + 2]];
                }
            }
            Console.WriteLine(elements[0]);

            Console.WriteLine("PART 2");
            int expectedResult = 19690720;
            int noun = -1, verb = 0;

            while (elements[0] != expectedResult)
            {
                if (noun == 99)
                {
                    noun = 0;
                    verb++;
                }
                else
                {
                    noun++;
                }
                if(verb == 100)
                {
                    Console.WriteLine("ERROR?");
                    break;
                }
                elements = Array.ConvertAll(entry, e => int.Parse(e)); ;
                elements[1] = noun;
                elements[2] = verb;
                for (int i = 0; elements[i] != 99; i += 4)
                {
                    if (elements[i] == 1)
                    {
                        elements[elements[i + 3]] = elements[elements[i + 1]] + elements[elements[i + 2]];
                    }
                    else if (elements[i] == 2)
                    {
                        elements[elements[i + 3]] = elements[elements[i + 1]] * elements[elements[i + 2]];
                    }
                }
            }
            Console.WriteLine($"el[1]: {noun}\nel[2]: {verb}\nResult (100 * el[1] + el[2]): {100 * noun + verb}");
            Console.ReadKey();
        }
    }
}
