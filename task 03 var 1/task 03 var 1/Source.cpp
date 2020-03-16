#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

//void main()
//{
//	int checkerValue = 0, repeater, inputValue, valueCounter = 0;
//	
//	printf("Enter number of iterations\n");
//	scanf("%d", &repeater);
//
//	for (int i = 0; i < repeater; i++)
//	{
//		printf("Enter value\n");
//		scanf("%d", &inputValue);
//
//		if (checkerValue > inputValue)
//		{
//			printf("%d more than %d\n", checkerValue, inputValue);
//			valueCounter++;
//		}
//
//		checkerValue = inputValue;
//	}
//
//	printf("%d number that are not less then their left neighbours", valueCounter);
//}

//void main()
//{
//	int repeater, repeaterValues, minValue, maxValue;
//
//	printf("Enter number of iterations\n");
//	scanf("%d", &repeater);
//
//	for (int i = 0; i < repeater; i++)
//	{
//		printf("Enter value\n");
//		scanf("%d", &repeaterValues);
//
//		if (i == 0 || minValue > repeaterValues)
//			minValue = repeaterValues;
//
//		if (i == 0 || maxValue < repeaterValues)
//			maxValue = repeaterValues;
//	}
//
//	printf("Max is %d\nMin is %d", maxValue, minValue);
//}

//void main()
//{
//	int valueA, valueB, repeaterValues, minValue = _CRT_INT_MAX, maxValue = 0;
//
//	printf("Enter A and B where 0 < A < B\n");
//	scanf("%d%d", &valueA, &valueB);
//
//	for (int i = 0; i < 10; i++)
//	{
//		printf("Enter value\n");
//		scanf("%d", &repeaterValues);
//
//		if (repeaterValues >= valueA & repeaterValues <= valueB)
//		{
//			if (minValue > repeaterValues)
//				minValue = repeaterValues;
//			if (maxValue < repeaterValues)
//				maxValue = repeaterValues;
//		}
//	}
//
//	printf("Max is %d\nMin is %d", maxValue, minValue);
//}

//void main()
//{
//	int daysCounter = 0;
//	float resultValue = 1000, increaseValue;
//
//	printf("Input value between 0 and 25\n");
//	scanf("%f", &increaseValue);
//
//	while (resultValue <= 1100)
//	{
//		resultValue += resultValue * (increaseValue / 100);
//		daysCounter++;
//	}
//
//	printf("%f %d \n", resultValue, daysCounter);
//}

void main()
{
	unsigned int valueA, valueB;

	printf("Enter values that A is more than B. Input in format A_B\n");
	scanf("%d%d", &valueA, &valueB);

	while (valueB < valueA)
	{
		valueA = valueA - valueB;
	} 

	printf("%d\n", valueA);
}