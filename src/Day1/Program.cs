using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("..\\..\\input\\input.txt", Encoding.UTF8);
            int sum = 0;
            foreach(string line in lines)
            {
                sum += Convert.ToInt32(int.Parse(line) / 3) - 2;
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
