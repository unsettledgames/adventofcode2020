using System;
using System.Collections.Generic;

namespace _6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] lines = System.IO.File.ReadAllLines("input.txt");
            int ret = 0;
            HashSet<char> answers = new HashSet<char>();

            foreach (String line in lines)
            {
                if (line.Equals(""))
                {
                    ret += answers.Count;
                    answers = new HashSet<char>();
                }
                else
                {
                    foreach (char c in line)
                    {
                        answers.Add(c);
                    }
                }
            }

            ret += answers.Count;

            Console.WriteLine(ret);
        }
    }
}
