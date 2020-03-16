#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

//void main()
//{
//	int numberOfDay;
//
//	printf("Enter the number of the day from 1 to 7\n");
//	scanf("%d", &numberOfDay);
//
//	switch (numberOfDay)
//	{
//	case 1: printf("Monday");
//		break;
//	case 2: printf("Tuesday");
//		break;
//	case 3: printf("Wednesday");
//		break;
//	case 4: printf("Thursday");
//		break;
//	case 5: printf("Friday");
//		break;
//	case 6: printf("Saturday");
//		break;
//	case 7: printf("Sunday");
//		break;
//	}
//}

void main()
{
	int operationIndex;
	float valueA, valueB, result;

	printf("Choose the action putting numbers from 1 to 4\n");
	scanf("%d", &operationIndex);

	printf("Enter values in format A:B\n");
	scanf("%f:%f", &valueA, &valueB);

	switch (operationIndex)
	{
	case 1: 
		 result = valueA + valueB;
		break;
	case 2:
		result = valueA - valueB;
		break;
	case 3:
		result = valueA * valueB;
		break;
	case 4:
		result = valueA / valueB;
		break;
	}

	printf("%.2f", result);
}