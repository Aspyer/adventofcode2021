using System;
using System.IO;
using System.Collections.Generic;

namespace day7
{
    internal class Program
    {
        
        public static void Main2(string[] args)
        {
            List<int> craby= new List<int>();
            int m = 0;
            int s = 0;
            foreach (string line in File.ReadLines(@"C:\Users\basdu\Downloads\day72021adventofcode.txt"))
            {
                foreach (string crab in line.Split(','))
                {
                    craby.Add(Convert.ToInt32(crab));
                }
            }
            craby.Sort();
            if ((craby.Count - 1) % 2 == 0)
            {
                int a = craby[(craby.Count - 1) / 2 - 1];
                int b = craby[(craby.Count - 1) / 2];
                m = (a + b) / 2;
            }
            else
            {
                m = craby[craby.Count / 2];
            }
            foreach (int crab in craby)
            {
                s += Math.Abs(crab - m);
            }
            
            Console.WriteLine(s);
            
        }
    }
}