using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace day2part2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var numbers = System.IO.File.ReadAllLines(@"C:\Users\basdu\Downloads\day22021adventofcode.txt").Select(o =>o.Split(' '));

            string direction = "";
            int i = 0;
            int x = 0;
            int y = 0;
            foreach (var instruction in numbers)
            {
                direction = instruction[0];
                i = int.Parse(instruction[1]);
                switch (direction)
                {
                    case "down":
                        y += i;
                        break;
                    case "up":
                        y -= i;
                        break;
                    case "forward":
                        x += i;
                        break;
                }
            }
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(x * y);

            int aim = 0;
            x = 0;
            y = 0;

            foreach (var instruction in numbers)
            {
                direction = instruction[0];
                i = int.Parse(instruction[1]);
                switch (direction)
                {
                    case "down":
                        aim += i;
                        break;
                    case "up":
                        aim -= i;
                        break;
                    case "forward":
                        x += i;
                        y += i * aim;
                        break;
                }
            }
            Console.WriteLine(y * x);
        }
    }
}
