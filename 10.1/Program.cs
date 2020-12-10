using System;
using System.Collections.Generic;

namespace _10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] lines = System.IO.File.ReadAllLines("input.txt");
            Dictionary<int, int> differences = new Dictionary<int, int>();
            List<int> jolts = new List<int>();

            differences.Add(1, 0);
            differences.Add(2, 0);
            differences.Add(3, 0);

            foreach (String line in lines)
            {
                jolts.Add(Int32.Parse(line));
            }

            jolts.Sort();

            // Charger output
            differences[jolts[0]]++;

            for (int i=1; i<jolts.Count; i++)
            {
                differences[jolts[i] - jolts[i - 1]]++;
            }

            // Device input
            differences[3]++;

            Console.WriteLine(differences[3] * differences[1]);
        }
    }
}
