using System;
using System.Collections.Generic;

namespace _5._2._1
{
    class Program
    {
        private static int ParseSeat(String id)
        {
            int row = Convert.ToInt32(id.Substring(0, 7).Replace('F', '0').Replace('B', '1'), 2);
            int col = Convert.ToInt32(id.Substring(7, 3).Replace('L', '0').Replace('R', '1'), 2);
            
            return row * 8 + col;
		}

        static void Main(string[] args)
        {
			String[] lines = System.IO.File.ReadAllLines("input.txt");
			List<int> ids = new List<int>();

			for (int i=0; i<lines.Length; i++)
            {
				int seat = Program.ParseSeat(lines[i]);

				ids.Add(seat);
            }

			for (int i=1; i<127; i++)
            {
				for (int j=0; j<8; j++)
                {
					int id = i * 8 + j;

					if (!ids.Contains(id) && ids.Contains(id + 1) && ids.Contains(id - 1))
                    {
						Console.WriteLine(id);
                    }
                }
            }
		}
    }
}
