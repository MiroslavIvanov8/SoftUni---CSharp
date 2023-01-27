int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] condensedArr = new int [0];
int sum = 0;
for (int i = 0; i < arr.Length - 1; i++)
{
    condensedArr = arr;
    //condensedArr[i] = arr[i] + arr[i + 1];
    for (int j = 0; j < condensedArr.Length - 1-i; j++)
    {
        condensedArr[j]= condensedArr[j] + condensedArr[j + 1];
    }
    condensedArr = arr;
}
Console.WriteLine(condensedArr[0]);