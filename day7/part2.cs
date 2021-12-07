using System;
using System.IO;
using System.Collections.Generic;

namespace day7
{
    internal class part2
    {
        
        public static void Main(string[] args)
        {
            List<int> craby= new List<int>();
            int m = 0;
            int t = 0;
            int s = 0;
            foreach (string line in File.ReadLines(@"C:\Users\basdu\Downloads\day72021adventofcode.txt"))
            {
                foreach (string crab in line.Split(','))
                {
                    craby.Add(Convert.ToInt32(crab));
                    t += Convert.ToInt32(crab);
                }
            }
            m = (int) Math.Ceiling((double) (t / (craby.Count)));
            
            foreach (int crab in craby)
            {
                int pos = Math.Abs(crab - m);
                s += (pos * (pos + 1)) / 2;
            }
            
            Console.WriteLine(s);
            
        }
    }
}