using System;
using System.Collections.Generic;

namespace _8._2
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] lines = System.IO.File.ReadAllLines("input.txt");
            HashSet<int> executedLines = new HashSet<int>();

            Program.PrintFinalAcc(lines, new HashSet<int>(), false, 0, 0);
        }

        private static void PrintFinalAcc(String[] lines, HashSet<int> executed, bool changed, int acc, int pc)
        {
            HashSet<int> tmp = new HashSet<int>();
            HashSet<int> param = new HashSet<int>();

            while (!executed.Contains(pc) && !tmp.Contains(pc))
            {
                if (pc >= lines.Length)
                {
                    Console.WriteLine(acc);
                    return;
                }

                String op = lines[pc].Substring(0, 3);
                int arg = Int32.Parse(lines[pc].Substring(3, lines[pc].Length - 3));

                tmp.Add(pc);

                if (op.Equals("jmp"))
                {
                    if (changed)
                    {
                        pc += arg;
                    }
                    else
                    {
                        param.UnionWith(executed);
                        param.UnionWith(tmp);

                        Program.PrintFinalAcc(lines, param, true, acc, pc + 1);
                        Program.PrintFinalAcc(lines, param, false, acc, pc + arg);
                    }

                }
                else if (op.Equals("acc"))
                {
                    acc += arg;
                    pc++;
                }
                else if (op.Equals("nop"))
                {
                    if (changed)
                    {
                        pc++;
                    }
                    else
                    {
                        param.UnionWith(executed);
                        param.UnionWith(tmp);

                        Program.PrintFinalAcc(lines, param, true, acc, pc + arg);
                        Program.PrintFinalAcc(lines, param, false, acc, pc + 1);
                    }
                }
            }

            return;
        }
    }
}
