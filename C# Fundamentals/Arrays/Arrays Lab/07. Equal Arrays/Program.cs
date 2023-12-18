int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
int sum = 0;
for(int i = 0; i < arr1.Length;i++)
{
    sum+= arr1[i];
    if (arr1[i] == arr2[i])
    {        
        if (i == arr1.Length - 1)
        {
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
    else
    {        
        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
        break;
    }     
    
}