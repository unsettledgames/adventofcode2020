#include <iostream>
#include <fstream>
#include <sstream>
#include <regex>

#define MAX_LENGTH 10000
#define MAX_WORDS 1000
#define MAX_LINES 10

using namespace std;

bool is_valid(string words[], int size)
{
	bool found[] = { false, false, false, false, false, false, false };
	string curr_data;

	for (int i = 0; i < size; i++)
	{
		curr_data = words[i].substr(words[i].find(':') + 1, words[i].length());

		if (words[i].find("byr") != std::string::npos)
		{
			int year = stoi(curr_data, nullptr);
			if (year >= 1920 && year <= 2002)
			{
				found[0] = true;
			}
		}
		else if(words[i].find("iyr") != std::string::npos)
		{
			int year = stoi(curr_data, nullptr);
			if (year >= 2010 && year <= 2020)
			{
				found[1] = true;
			}
		}
		else if (words[i].find("eyr") != std::string::npos)
		{
			int year = stoi(curr_data, nullptr);
			if (year >= 2020 && year <= 2030)
			{
				found[2] = true;
			}
		}
		else if (words[i].find("hgt") != std::string::npos)
		{
			int height;

			if (curr_data.find("cm") != std::string::npos)
			{
				height = stoi(curr_data.substr(0, 3), nullptr);
				if (height >= 150 && height <= 193)
				{
					found[3] = true;
				}
			}
			else if (curr_data.find("in") != std::string::npos)
			{
				height = stoi(curr_data.substr(0, 2), nullptr);
				if (height >= 59 && height <= 76)
				{
					found[3] = true;
				}
			}
		}
		else if (words[i].find("hcl") != std::string::npos)
		{
			if (std::regex_match(curr_data, std::regex("#([a-f0-9]){6}\\b")))
			{
				found[4] = true;
			}
		}
		else if (words[i].find("ecl") != std::string::npos)
		{
			if ((curr_data.find("amb") != std::string::npos || curr_data.find("brn") != std::string::npos ||
				curr_data.find("gry") != std::string::npos || curr_data.find("grn") != std::string::npos ||
				curr_data.find("hzl") != std::string::npos || curr_data.find("oth") != std::string::npos ||
				curr_data.find("blu") != std::string::npos) && curr_data.length() == 3)
			{
				found[5] = true;
			}
		}
		else if (words[i].find("pid") != std::string::npos)
		{
			if (std::regex_match(curr_data, std::regex("([0-9])+\\b")) && curr_data.length() == 9)
			{
				found[6] = true;
			}
		}
	}

	return found[0] && found[1] && found[2] && found[3] && found[4] && found[5] && found[6];
}

int main()
{
	fstream file;
	stringstream file_buffer;

	string whole_input;
	string lines[MAX_WORDS];
	string current_line = "a";

	int start_pos = 0;
	int end_pos = 0;
	int n_valid = 0;
	int line_index;


	file.open("input.txt");

	file_buffer << file.rdbuf() << '§';
	whole_input = file_buffer.str();
	whole_input = regex_replace(whole_input, std::regex("\n"), " ");

	int j = 0;

	while (end_pos != std::string::npos)
	{
		line_index = 0;
		current_line = "a";

		// Splitting the input into lines until I find a blank one
		while (!current_line.empty() && end_pos != std::string::npos)
		{
			end_pos = whole_input.find(' ');

			current_line = whole_input.substr(start_pos, end_pos);
			whole_input = whole_input.substr(end_pos + 1, whole_input.length());

			lines[line_index] = current_line;
			line_index++;

			j++;
		}

		if (is_valid(lines, line_index))
		{
			n_valid++;
		}

		cout << j << endl;
	}

	cout << n_valid << endl;

	file.close();

}