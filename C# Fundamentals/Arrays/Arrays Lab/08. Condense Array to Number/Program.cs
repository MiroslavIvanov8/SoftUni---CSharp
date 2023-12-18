int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] condensedArr = new int [arr.Length];
int sum = 0;
for (int i = 0; i < arr.Length-1; i++)
{
    condensedArr = arr;    
    for (int j = 0; j < condensedArr.Length - 1-i; j++)
    {
        condensedArr[j]= condensedArr[j] + condensedArr[j + 1];
    }
    condensedArr = arr;
}
if(arr.Length == 1)
 condensedArr = arr;
Console.WriteLine(condensedArr[0]);