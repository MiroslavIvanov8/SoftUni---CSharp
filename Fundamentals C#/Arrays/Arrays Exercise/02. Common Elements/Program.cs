string[] firstArray = Console.ReadLine().Split();
string[] secondArray = Console.ReadLine().Split(); 
for (int i = 0; i < secondArray.Length; i++) // M i R K => i[0] = M
{
    for (int j = 0; j < firstArray.Length; j++) // M n M R => j[0]= M,j[1]= n, j[2]= M
    {
        if (secondArray[i] == firstArray[j]) // we compare first i[0]=M with all elements from the first Array.
        {
            Console.Write(secondArray[i]+ " ");
        }
    }
}
