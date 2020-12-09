using System;
using System.Collections.Generic;

namespace _9._1
{
    class Program
    {
        private static bool IsSum(Queue<int> numbers, int sum)
        {
            foreach (int i in numbers)
            {
                foreach (int j in numbers)
                {
                    if (i + j == sum && i != j)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            String[] lines = System.IO.File.ReadAllLines("input.txt");
            Queue<int> numbers = new Queue<int>();
            int min = int.MaxValue;
            int max = int.MinValue;
            int i = 0;

            for (i=0; i<25; i++)
                numbers.Enqueue(Int32.Parse(lines[i]));

            while (i < lines.Length && Program.IsSum(numbers, Int32.Parse(lines[i])))
            {
                numbers.Dequeue();
                numbers.Enqueue(Int32.Parse(lines[i]));

                i++;
            }
                

            Console.WriteLine(lines[i]);
        }
    }
}
