int[] numArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
int evenSum = 0;
int oddSum = 0;
for (int i = 0; i < numArr.Length; i++)
{
    if (numArr[i] % 2 == 0)
        evenSum += numArr[i];
    else
        oddSum += numArr[i];
}
int result = evenSum-oddSum;
Console.Write(result);