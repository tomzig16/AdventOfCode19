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
            //Console.WriteLine(sum);
            Console.WriteLine("Part 2");

            sum = 654;
            int p2sum = 0;
            int lastMass = sum;
            while(lastMass > 0)
            {
                p2sum += lastMass;
                lastMass = Convert.ToInt32(lastMass / 3) - 2;
                //p2sum += lastMass > 0 ? lastMass : 0;
            }
            //p2sum += sum;
            Console.WriteLine(p2sum);
            Console.ReadKey();
        }
    }
}
