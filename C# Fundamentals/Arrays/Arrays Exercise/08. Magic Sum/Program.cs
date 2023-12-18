int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
int magicNum = int.Parse(Console.ReadLine());
int sum = 0;
int j = 0;
for(int i = 0;i<inputArr.Length-1;i++)
{
    
    for (j = i+1; j < inputArr.Length; j++)        
    {
        sum = 0;
        sum = inputArr[i] + inputArr[j];
        if (sum == magicNum)
        {
            Console.WriteLine($"{inputArr[i]} {inputArr[j]}");
        }
    }    
}


