using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace day9
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        const int COUNT = 100;

            static int[,] ReadInput()
            {
                int[,] input = new int[COUNT, COUNT];
                var inputLines = File.ReadAllLines(@"C:\Users\basdu\Downloads\day92021adventofcode.txt");
                for (int i = 0; i < COUNT; i++)
                for (int j = 0; j < COUNT; j++) 
                    input[i, j] = inputLines[i][j] - '0';
                return input;
            }

            static IEnumerable<(int i, int j)> GetLowestPoints(int[,] input)
            {
                for (int i = 0; i < COUNT; i++)
                for (int j = 0; j < COUNT; j++)
                {
                    if ((i - 1 < 0 || input[i - 1, j] > input[i, j]) &&
                        (i + 1 >= COUNT || input[i, j] < input[i + 1, j]) &&
                        (j - 1 < 0 || input[i, j - 1] > input[i, j]) &&
                        (j + 1 >= COUNT || input[i, j] < input[i, j + 1]))
                    {
                        yield return (i, j);
                    }
                }
            }

            static void Part1()
            {
                int[,] input = ReadInput();

                int riskLevel = 0;
                foreach ((int i, int j) in GetLowestPoints(input))
                    riskLevel += 1 + input[i, j];

                Console.WriteLine(riskLevel);
            }

            static void Part2()
            {
                int[,] input = ReadInput();
                var lowestpoints = GetLowestPoints(input);
                var bsizes = new List<int>(100);
                foreach ((int x, int y ) in lowestpoints)
                {
                    int bsize = GetSize(ref input, Directions.down, x + 1, y) +
                                 GetSize(ref input, Directions.left, x, y - 1) +
                                 GetSize(ref input, Directions.right,x, y + 1) +
                                 GetSize(ref input, Directions.up, x - 1, y);
                    bsizes.Add(bsize);
                }
                int basinSizesMultiplied = bsizes.OrderByDescending(s => s).Take(3).Aggregate(1, (s, i) => s *= i);
                Console.WriteLine(basinSizesMultiplied);
            }

            enum Directions
            {
                up,
                right,
                left,
                down
            }

            static int GetSize(ref int[,] input, Directions direction,int i, int j)
            {
                if (i < 0 || j < 0 || i >= COUNT || j >= COUNT)
                    return 0;
                if (input[i, j] == 9)
                    return 0;
                input[i, j] = 9;
                int size = 1;

                size += direction != Directions.up ? GetSize(ref input, Directions.down, i + 1, j) : 0;
                size += direction != Directions.right ? GetSize(ref input, Directions.left, i, j - 1) : 0;
                size += direction != Directions.left ? GetSize(ref input, Directions.right, i, j + 1) : 0;
                size += direction != Directions.down ? GetSize (ref input, Directions.up, i - 1, j) : 0;
                return size;
            }
        }
    }
