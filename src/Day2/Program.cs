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
        }
    }
}
