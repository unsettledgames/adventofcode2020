#include <iostream>
#include <fstream>
#include <sstream>

#define MAX_LENGTH 10000
#define MAX_LINES 10

using namespace std;

bool check_tags(string lines[],  int size)
{
	string line = "";

	for (int i = 0; i < size; i++)
	{
		line += lines[i];
	}

	return line.find("byr") != std::string::npos &&
		line.find("iyr") != std::string::npos &&
		line.find("eyr") != std::string::npos &&
		line.find("hgt") != std::string::npos &&
		line.find("hcl") != std::string::npos &&
		line.find("ecl") != std::string::npos &&
		line.find("pid") != std::string::npos;
}

int main()
{
	fstream file;
	stringstream file_buffer;

	string whole_input;
	string lines[MAX_LINES];
	string current_line = "a";

	int start_pos = 0;
	int end_pos = 0;
	int n_valid = 0;
	int line_index;
	

	file.open("input.txt");

	file_buffer << file.rdbuf() << '§';
	whole_input = file_buffer.str();

	while (end_pos != std::string::npos)
	{
		line_index = 0;
		current_line = "a";
		
		// Splitting the input into lines until I find a blank one
		while (!current_line.empty() && end_pos != std::string::npos)
		{
			end_pos = whole_input.find('\n');
			
			current_line = whole_input.substr(start_pos, end_pos);
			whole_input = whole_input.substr(end_pos + 1, whole_input.length());

			lines[line_index] = current_line;
			line_index++;
		}

		if (check_tags(lines, line_index))
		{
			n_valid++;
		}

		cout << n_valid << endl;
	}

	cout << n_valid << endl;

	file.close();

}