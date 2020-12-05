#include <iostream>
#include <fstream>

#define MAX_ROW 127
#define MIN_ROW 0
#define MAX_COL 8
#define MIN_COL 0

using namespace std;

int get_id(string seat)
{
	int curr_max_row = 127;
	int curr_min_row = 0;
	int curr_min_col = 0;
	int curr_max_col = 7;

	int row, col;

	bool keep_low_row = false;
	bool keep_low_col = false;

	for (int i = 0; i < seat.length(); i++)
	{
		switch (seat[i])
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

int main()
{
	fstream file;
	string current_seat;
	int current_id;
	int max_id = -1;

	file.open("input.txt");

	while (!file.eof())
	{
		file >> current_seat;
		current_id = get_id(current_seat);

		if (current_id > max_id)
		{
			max_id = current_id;
		}
	}

	cout << max_id;

	file.close();

}