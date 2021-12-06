using System;
using System.CodeDom;
using System.Linq;
using System.Collections.Generic;

namespace day3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var numbers = System.IO.File.ReadAllLines(@"C:\Users\basdu\Downloads\day32021adventofcode.txt");
            var gamma = "";
            var epsilon = "";
            var countgamma = new List<int>()
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach (var number in numbers)
            {
                for (var i = 0; i < number.Length; i++)
                {
                    if (number[i] == '1')
                    {
                        countgamma[i] += 1;
                    }
                }
            }

            foreach (var cg in countgamma)
            {
                if (cg > 500)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }

            var gd = Convert.ToInt64(gamma, 2);
            var ed = Convert.ToInt64(epsilon, 2);
            Console.WriteLine(gd * ed);
            {
                
            }
           
            
            List<string> newList = numbers.OfType<string>().ToList();

            while (newList.Count != 1)
            {
                for (int x = 0; x < numbers[0].Length; x++)
                {
                    newList = PopOxygen(newList, x);
                }
            }
            var oxygenDec = Convert.ToInt64(newList[0], 2);
            
            newList = numbers.OfType<string>().ToList();
            while (newList.Count != 1)
            {
                for (int x = 0; x < numbers[0].Length; x++)
                {
                    newList = PopCo2(newList, x);
                    if (newList.Count == 1) break;
                }
            }
            var o2Dec = Convert.ToInt64(newList[0], 2);
            
            Console.WriteLine(oxygenDec * o2Dec);
        }

        static List<string> PopOxygen(List<string> lines, int bit)
        {
          
            var mostCommon = '0';
            var countone = lines.Count(line => line[bit] == '1');
            var countzero = lines.Count - countone;
            
            if (countone > countzero) mostCommon = '1';
            
            if (countone == countzero) mostCommon = '1';
            
            return lines.Where(line => line[bit] == mostCommon).ToList();
        }

        static List<string> PopCo2(List<string> lines, int bit)
        {
            var leastCommon = '0';
            var oneCount = lines.Count(line => line[bit] == '1');
            var zeroCount = lines.Count - oneCount;
            
            if (oneCount < zeroCount) leastCommon = '1';
            if (oneCount == zeroCount) leastCommon = '0';

            return lines.Where(line => line[bit] == leastCommon).ToList();
        }
        }
    }
