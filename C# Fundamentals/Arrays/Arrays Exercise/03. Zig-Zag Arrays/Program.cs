int n = int.Parse(Console.ReadLine());
int[] oddArr1 = new int[n];
int[] evenArr2 = new int[n];
int cnt = 0;
for (int i = 0; i < n; i++)
{
    cnt++;
    int[] numbers =Console.ReadLine().Split().Select(int.Parse).ToArray();
    if (cnt % 2 !=0)
    {
        oddArr1[i] += numbers[0];
        evenArr2[i]+= numbers[1];
    }
    else
    {
        oddArr1[i] += numbers[1];
        evenArr2[i]+= numbers[0];
    }
}
 Console.WriteLine(string.Join(" ",oddArr1));
Console.WriteLine(string.Join(" ", evenArr2));