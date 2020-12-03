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
	int read_i = 0, curr_x = 0, curr_y = 0, n_trees = 0;
	int width;
	fstream file;

	file.open("input.txt");

	// Getting the input
	while (!file.eof())
	{
		cout << read_i << endl;
		file >> field[read_i];

		read_i++;
	}

	file.close();

	width = get_width(field);

	curr_x += 3;
	curr_y += 1;

	// Navigating the field
	while (curr_y < read_i - 1)
	{
		if (field[curr_y][curr_x] == '#')
		{
			n_trees++;
		}

		curr_x = (curr_x + 3) % width;
		curr_y += 1;
	}

	cout << n_trees;

}