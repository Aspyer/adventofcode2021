using System;
using System.Linq;
using System.IO;


namespace adventofcode
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
            
            Console.WriteLine(count);
            
                }
            }
}
    

