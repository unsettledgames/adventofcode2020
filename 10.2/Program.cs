using System;
using System.Collections.Generic;
using System.Numerics;

namespace _10._2
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] lines = System.IO.File.ReadAllLines("input.txt");
            List<int> jolts = new List<int>();
            BigInteger ret = new BigInteger(1);
            Dictionary<int, BigInteger> paths = new Dictionary<int, BigInteger>();

            foreach (String line in lines)
            {
                int n = Int32.Parse(line);

                if (!jolts.Contains(n))
                {
                    jolts.Add(n);
                    paths[n] = 0;
                }
            }

            jolts.Add(0);
            jolts.Sort();
            jolts.Add(jolts[jolts.Count - 1] + 3);
            paths[0] = 1;
            paths[jolts[jolts.Count - 1]] = 0;


            for (int i=0; i<jolts.Count - 1; i++)
            {
                int j = i + 1;

                while (j < jolts.Count && jolts[j] - jolts[i] <= 3)
                {
                    paths[jolts[j]] += paths[jolts[i]];
                    j++;
                }
            }

            Console.WriteLine(paths[jolts[jolts.Count - 1]]);
        }
    }
}
