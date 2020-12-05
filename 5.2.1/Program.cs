using System;
using System.Collections.Generic;

namespace _5._2._1
{
    class Program
    {
        private static int ParseSeat(String id)
        {
			int curr_max_row = 127;
			int curr_min_row = 0;
			int curr_min_col = 0;
			int curr_max_col = 7;

			int row, col;

			bool keep_low_row = false;
			bool keep_low_col = false;

			for (int i = 0; i < id.Length; i++)
			{
				switch (id[i])
				{
					case 'F':
						curr_max_row = (curr_min_row + curr_max_row) / 2;
						keep_low_row = true;
						break;
					case 'B':
						curr_min_row = (curr_min_row + curr_max_row) / 2;
						keep_low_row = false;
						break;
					case 'L':
						curr_max_col = (curr_min_col + curr_max_col) / 2;
						keep_low_col = true;
						break;
					case 'R':
						curr_min_col = (curr_min_col + curr_max_col) / 2;
						keep_low_col = false;
						break;
				}
			}

			if (keep_low_row)
			{
				row = curr_min_row;
			}
			else
			{
				row = curr_max_row;
			}

			if (keep_low_col)
			{
				col = curr_min_col;
			}
			else
			{
				col = curr_max_col;
			}

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
				for (int j=0; i<8; j++)
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
