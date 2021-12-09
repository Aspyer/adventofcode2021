using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Users\basdu\Downloads\day82021adventofcode.txt");
			
            int day8Part1Solution = 0;

            foreach (var item in input)
            {
                var s = item.Split('|');
                var t = s[0].Split(' ').Select(y => String.Concat(y.OrderBy(x => x))).OrderBy(x => x.Length).ToArray();
                var o = s[1].Split(' ').Select(y => String.Concat(y.OrderBy(x => x))).ToArray();

                Dictionary<string, int> numbers = new Dictionary<string, int>();
                numbers.Add(t[0], 1);	
                numbers.Add(t[1], 7);    
                numbers.Add(t[2], 4);   
                numbers.Add(t[3], 8);
                
                for (int i = 0; i < o.Length; i++)
                {
                    if (o[i].Length == 2 || o[i].Length == 4 || o[i].Length == 3 || o[i].Length == 7)
                        day8Part1Solution++;
                }
            }
            Console.WriteLine(day8Part1Solution);
        }
    }
}