#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

void main()
{
	int iterationValue;

	printf("Enter number of iterations\n");
	scanf("%d", &iterationValue);

	for (int i = 0; i < iterationValue; i++)
	{
		printf("%d %d %d %d %d\n", i+1,i+1,i+1,i+1,i+1);
	}
}

//void main()
//{
//	int iterationValue;
//
//	printf("Enter number of iterations\n");
//	scanf("%d", &iterationValue);
//
//	for (int i = 1; i <= iterationValue; i++)
//	{
//		printf("%d ", i);
//		for (int j = 1; j <= iterationValue - i; j++)
//		{
//				printf("%d ", j + i);
//		}
//		printf("\n");
//	}
//}