using System;
using System.Linq;
using System.IO;

namespace day1part2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = File.ReadAllLines(@"C:\Users\basdu\Downloads\day1part12021adventofcode.txt")
                .Select(number => int.Parse(number)).ToArray();
            
            
            int count = 0;
            int beginnumber = numbers[0];
            int i = 1;
            int j = 0;

            foreach (int number in numbers)
            {
                if (i < numbers.Length)
                {
                    if (numbers[i] > numbers[j])
                    {
                        count++;
                    }
                    i++;
                    j++;
                }
            }
            int count2 = 0;
            int a = 0;
            
            foreach (int number in numbers)
            {
                if (a+3< numbers.Length)
                {
                    int measurment1 = numbers[a] + numbers[a + 1] + numbers[a + 2];
                    int measurment2 = numbers[a + 1] + numbers[a + 2] + numbers[a + 3];
                    if (measurment1 < measurment2)
                    {
                        count2++;
                    }

                    a++;
                }
            }
            
            Console.WriteLine(count);
            Console.WriteLine(count2);

        }
    }
}