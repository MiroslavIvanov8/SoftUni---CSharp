




int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
for (int i = 0; i < inputNumbers.Length; i++)
{
    bool isTop = true;
    for (int j = i+1; j < inputNumbers.Length;j++)
    {                                                                   
        if (inputNumbers[i] <= inputNumbers[j])                          //   0  1  2  3  4  5  6
                                                                         //   27 19 42 2 13 45 48 :: 48 47 19 42 2 13 45 27
        {
            isTop = false;
            break;
        }
    }     
    if(isTop)
    {
        Console.Write(inputNumbers[i] + " ");
    }    
   
}

