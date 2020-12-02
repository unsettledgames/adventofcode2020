#include <iostream>
#include <fstream>
#include <string>

#define MAX_WORD_LENGTH 100

using namespace std;

int count(char* s, char c)
{
	int ret = 0;

	for (int i = 0; i < strlen(s); i++)
	{
		if (s[i] == c)
		{
			ret++;
		}
	}

	return ret;
}

int main()
{
	int ret = 0;
	int min, max;
	char c;
	char current_word[MAX_WORD_LENGTH];
	FILE* file = fopen("input.txt", "r");

	while (!feof(file))
	{
		fscanf(file, "%d-%d %c: %s\n", &min, &max, &c, current_word);

		int curr_count = count(current_word, c);
		

		if (curr_count >= min && curr_count <= max)
		{
			ret++;
		}
	}

	fclose(file);

	cout << ret;
}