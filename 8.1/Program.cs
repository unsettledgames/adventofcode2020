using System;
using System.Collections.Generic;

namespace _8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] lines = System.IO.File.ReadAllLines("input.txt");
            HashSet<int> executedLines = new HashSet<int>();

            int pc = 0;
            int acc = 0;

            while (!executedLines.Contains(pc))
            {
                String op = lines[pc].Substring(0, 3);
                int arg = Int32.Parse(lines[pc].Substring(3, lines[pc].Length - 3));

                executedLines.Add(pc);

                if (op.Equals("jmp"))
                {
                    pc += arg;
                }
                else if (op.Equals("acc"))
                {
                    acc += arg;
                    pc++;
                }
                else
                {
                    pc++;
                }
            }

            Console.WriteLine(acc);

        }
    }
}
