int numbers = int.Parse(Console.ReadLine());
int[] numbersArr = new int[numbers];

for (int i = 0; i < numbersArr.Length; i++)
{
    
    numbersArr[i]= int.Parse(Console.ReadLine());
}

//int[] reverseNumbers = numbersArr.Reverse().ToArray(); 
//for(int i =0; i<reverseNumbers.Length;i++)
//{
//    Console.Write(reverseNumbers[i] + " ");
//}

for (int i = numbersArr.Length-1; i >= 0; i--)
{
    Console.Write(numbersArr[i] + " ");
}


int[] arr = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();