#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void main()
{
	int arrayOfInt[5][5];

	srand(time(NULL));

	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			arrayOfInt[i][j] = rand() % 10;

			printf("%d ", arrayOfInt[i][j]);
		}
		printf("\n");
	}

	printf("Sorting...\n");

	for (int i = 0; i < 5; i++)
	{
		for (int f = 0; f < 5; f++)
		{
			for (int s = 0; s < f; s++)
			{
				if (arrayOfInt[i][f] < arrayOfInt[i][s])
				{
					arrayOfInt[i][f] ^= arrayOfInt[i][s];
					arrayOfInt[i][s] ^= arrayOfInt[i][f];
					arrayOfInt[i][f] ^= arrayOfInt[i][s];
				}
			}
		}
	}

	printf("New...\n");

	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			printf("%d ", arrayOfInt[i][j]);
		}
		printf("\n");
	}
}