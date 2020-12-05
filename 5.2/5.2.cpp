#include <iostream>
#include <fstream>
#include <vector>

#define MAX_ROW 127
#define MIN_ROW 0
#define MAX_COL 8
#define MIN_COL 0
#define MAX_LENGTH 1000

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

bool cursed_list_search_imdonewithcplusplus(std::vector<int> l, int val)
{
	for (int i = 0; i < l.size(); i++)
	{
		if (l[i] == val)
		{
			return true;
		}
	}

	return false;
}

int main()
{
	fstream file;
	string current_seat;
	int current_id;
	int i = 0;
	std::vector<int> ids;

	file.open("input.txt");

	while (!file.eof())
	{
		file >> current_seat;
		ids.push_back(get_id(current_seat));

		i++;
	}

	for (i = 1; i < 126 * 8; i++)
	{
		if (!cursed_list_search_imdonewithcplusplus(ids, i) && cursed_list_search_imdonewithcplusplus(ids, i + 1) &&
			cursed_list_search_imdonewithcplusplus(ids, i - 1))
		{
			cout << i << endl;
		}
	}

	file.close();
}