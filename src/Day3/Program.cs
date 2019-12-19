using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        struct Position
        {
            public int x, y;

            public Position GetAbsVal()
            {
                Position newPosition = new Position();
                newPosition.x = Math.Abs(x);
                newPosition.y = Math.Abs(y);
                return newPosition;
            }
        }
        class PositionComparer : IEqualityComparer<Position>
        {
            public bool Equals(Position first, Position second)
            {
                return (first.x == second.x && first.y == second.y);
            }

            public int GetHashCode(Position obj)
            {
                return obj.x.GetHashCode() ^ obj.y.GetHashCode();
            }
        }

        static void Main(string[] args)
        {
            string[] entry = File.ReadAllLines("..\\..\\input\\input.txt", Encoding.UTF8);
            string[] firstWireDirs = entry[0].Split(',');
            string[] secondWireDirs = entry[1].Split(',');

            List<Position> firstWirePositions = GetWirePositions(firstWireDirs);
            List<Position> secondWirePositions = GetWirePositions(secondWireDirs);

            IEnumerable<Position> sameEntries = firstWirePositions.Intersect(secondWirePositions, new PositionComparer());

            Position closestPosition = sameEntries.First();

            foreach(Position intersection in sameEntries)
            {
                if ((intersection.GetAbsVal().x < closestPosition.GetAbsVal().x) &&
                    (intersection.GetAbsVal().y < closestPosition.GetAbsVal().y))
                {
                    closestPosition = intersection;
                }
            }
            Console.WriteLine($"Result: {closestPosition.GetAbsVal().x + closestPosition.GetAbsVal().y}");
            Console.ReadKey();
        }

        static List<Position> GetWirePositions(string[] directions)
        {
            List<Position> result = new List<Position>();
            Position currentPosition = new Position();
            currentPosition.x = currentPosition.y = 0;
            foreach(string entry in directions)
            {
                int numberOfSteps = int.Parse(entry.Substring(1));
                char direction = entry[0];
                for(int i = 1; i <= numberOfSteps; i++)
                {
                    switch (direction)
                    {
                        case 'R':
                            currentPosition.x++;
                            break;
                        case 'U':
                            currentPosition.y++;
                            break;
                        case 'L':
                            currentPosition.x--;
                            break;
                        case 'D':
                            currentPosition.y--;
                            break;
                    }
                    result.Add(currentPosition);
                }
            }

            return result;
        }
    }
}
