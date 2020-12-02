// 1.1.cpp : Questo file contiene la funzione 'main', in cui inizia e termina l'esecuzione del programma.
//

#include <iostream>
#include <fstream>

#define MAX_LENGTH 10000

using namespace std;

int main()
{
	fstream file;
	int input_array[MAX_LENGTH];
	int size = 0;

	file.open("input.txt");

	while (!file.eof())
	{
		file >> input_array[size];
		size++;
	}

	file.close();

	for (int i = 0; i < (size - 1); i++)
	{
		for (int j = i; j < (size - 1); j++)
		{
			for (int h = j; h < (size - 1); h++)
			{
				if ((input_array[i] + input_array[j] + input_array[h]) == 2020)
				{
					cout << input_array[i] * input_array[j] * input_array[h];

					return 0;
				}
			}
			
		}
	}
}