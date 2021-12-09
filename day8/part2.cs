using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace part2
{
    class Program
    {
        public static Dictionary<string, int> mapping = new Dictionary<string, int>();
        public static Dictionary<int, string> reverseMapping = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            int mt = 0;
            int tm = 0;
            string[] v;
            int m = 0;
            string ss = "";
            int ov = 0;

            foreach (string line in File.ReadLines(@"C:\Users\basdu\Downloads\day82021adventofcode.txt"))
            {
                mapping = new Dictionary<string, int>();
                reverseMapping = new Dictionary<int, string>();
                tm = 0;
                v = line.Split('|');

                foreach (string signal in v[0].Split(' '))
                {
                    ss = SortString(signal);
                    mt = -1;
                    if (ss.Length > 0)
                    {
                        if (ss.Length == 7)
                        {
                            mt = 8;
                            tm++;
                        }
                        else if (ss.Length == 4)
                        {
                            mt = 4;
                            tm++;
                        }
                        else if (ss.Length == 3)
                        {
                            mt = 7;
                            tm++;
                        }
                        else if (ss.Length == 2)
                        {
                            mt = 1;
                            tm++;
                        }

                        mapping.Add(ss, mt);
                        if (mt >= 0)
                        {
                            reverseMapping.Add(mt, ss);
                        }
                    }
                }
                // Deze deed pijn 
                while (tm < 10)
                {
                    m = 0;
                    foreach (string signal in mapping.Keys)
                    {
                        if (signal.Length > 0 && mapping[signal] < 0)
                        {
                            if (signal.Length == 6)
                            {
                                m = 0;
                                foreach (char a in reverseMapping[1])
                                    if (signal.Contains(a))
                                    {
                                        m++;
                                    }

                                if (m == reverseMapping[1].Length)
                                {
                                    m = 0;
                                    foreach (char a in reverseMapping[4])
                                        if (signal.Contains(a))
                                        {
                                            m++;
                                        }

                                    if (m == reverseMapping[4].Length)
                                    {
                                        tm++;
                                        reverseMapping.Add(9, signal);
                                        mapping[signal] = 9;
                                        break;
                                    }
                                    else
                                    {
                                        tm++;
                                        reverseMapping.Add(0, signal);
                                        mapping[signal] = 0;
                                        break;
                                    }
                                }
                                else
                                {
                                    tm++;
                                    reverseMapping.Add(6, signal);
                                    mapping[signal] = 6;
                                    break;
                                }
                            }
                            else if (signal.Length == 5)
                            {
                                m = 0;
                                foreach (char a in reverseMapping[7])
                                    if (signal.Contains(a))
                                    {
                                        m++;
                                    }

                                if (m == reverseMapping[7].Length)
                                {
                                    tm++;
                                    reverseMapping.Add(3, signal);
                                    mapping[signal] = 3;
                                    break;
                                }
                                else
                                {
                                    m = 0;
                                    if (reverseMapping.ContainsKey(9))
                                    {
                                        foreach (char a in reverseMapping[9])
                                            if (signal.Contains(a))
                                            {
                                                m++;
                                            }

                                        if (m == signal.Length)
                                        {
                                            tm++;
                                            reverseMapping.Add(5, signal);
                                            mapping[signal] = 5;
                                            break;
                                        }
                                        else
                                        {
                                            tm++;
                                            reverseMapping.Add(2, signal);
                                            mapping[signal] = 2;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                string outputString = "";
                foreach (string output in v[1].Split(' '))
                {
                    if (output.Length > 0)
                    {
                        outputString += mapping[SortString(output)].ToString();
                    }
                }

                ov += Convert.ToInt32(outputString);
            }

            Console.WriteLine("output: " + ov);
        }

        static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}