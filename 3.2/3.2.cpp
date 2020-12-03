#include <iostream>
#include <fstream>

using namespace std;

int get_width(char field[][50])
{
	int ret = 0;

	while (field[0][ret] != '\0')
	{
		ret++;
	}

	return ret;
}

int main()
{
	char field[1000][50];
	int x[] = { 1, 3, 5, 7, 1 };
	int y[] = { 1, 1, 1, 1, 2 };
	long results[5];
	long read_i = 0, curr_x = 0, curr_y = 0, n_trees = 0;
	int width;
	fstream file;

	file.open("input.txt");

	// Getting the input
	while (!file.eof())
	{
		file >> field[read_i];

		read_i++;
	}

	file.close();

	width = get_width(field);

	for (int i = 0; i < 5; i++)
	{
		curr_x = x[i];
		curr_y = y[i];

		// Navigating the field
		while (curr_y < read_i)
		{
			if (field[curr_y][curr_x] == '#')
			{
				n_trees++;
			}

			curr_x = (curr_x + x[i]) % width;
			curr_y += y[i];
		}

		cout << n_trees << endl;

		results[i] = n_trees;
		n_trees = 0;
	}
}