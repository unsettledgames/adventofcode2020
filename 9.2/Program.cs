using System;
using System.Collections.Generic;

namespace _9._2
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

        private static int FindVulnerability(List<int> numbers, int number)
        {
            int currSum = numbers[0];
            int min = 0;
            int max = 0;
            List<int> taken = new List<int>();

            taken.Add(numbers[0]);

            do
            {
                if (currSum > number)
                {
                    taken.Remove(numbers[min]);
                    currSum -= numbers[min];
                    min++;
                }
                else
                {
                    max++;

                    currSum += numbers[max];
                    taken.Add(numbers[max]);
                }
            } while (number != currSum && max < numbers.Count - 1);

            taken.Sort();

            return taken[0] + taken[taken.Count - 1];
        }

        static void Main(string[] args)
        {
            String[] lines = System.IO.File.ReadAllLines("input.txt");
            Queue<int> numbers = new Queue<int>();
            List<int> allNumbers = new List<int>();
            int min = int.MaxValue;
            int max = int.MinValue;
            int i = 0;

            for (i = 0; i < 25; i++)
            {
                int curr = Int32.Parse(lines[i]);

                numbers.Enqueue(curr);
                allNumbers.Add(curr);
            }
                

            while (i < lines.Length && Program.IsSum(numbers, Int32.Parse(lines[i])))
            {
                int curr = Int32.Parse(lines[i]);
                
                numbers.Dequeue();
                numbers.Enqueue(curr);

                allNumbers.Add(curr);
                i++;
            }


            Console.WriteLine(Program.FindVulnerability(allNumbers, Int32.Parse(lines[i])));
        }
    }
}
