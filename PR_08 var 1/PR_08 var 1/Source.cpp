#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void main()
{
	int sum, times = 0, size, element = 0, smallestSum = 0, intArr[27];

	for (int i = 0; i < 27; i++)
	{
		intArr[i] = 0;
	}

	printf("Enter number of values\n");
	scanf("%d", &size);

	for (int i = 0; i < size; i++)
	{
		element = rand() % 1000;
		printf("generated %d\n", element);

		if (element < 10)
		{
			sum = element;
		}
		else if (element < 100 & element > 9)
		{
			sum = element / 10 + element % 10;
		}
		else
		{
			sum = element / 100 + element % 10 + element % 100 / 10;
		}

		intArr[sum]++;

		printf("which sum is %d\n", sum);
	}

	for (int i = 0; i < 27; i++)
	{
		printf(" %d ", intArr[i]);
	}


	for (int i = 0; i < 27; i++)
	{
		if (times < intArr[i])
		{
			times = intArr[i];
			smallestSum = i;
		}
		else if (times == intArr[i] && smallestSum > i)
		{
			times = intArr[i];
			smallestSum = i;
		}
	}

	printf("\nThe smallest sum is %d and can be seen %d times", smallestSum, times);
}