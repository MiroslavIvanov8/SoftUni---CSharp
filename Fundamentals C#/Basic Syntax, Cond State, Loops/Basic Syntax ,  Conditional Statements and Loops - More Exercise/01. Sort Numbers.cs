int a;
int b;
int c;
a = int.Parse(Console.ReadLine());
b = int.Parse(Console.ReadLine());
c = int.Parse(Console.ReadLine());
int[] arr = new int[] { a, b, c };

Array.Sort(arr);
Array.Reverse(arr);

foreach (int value in arr)
{
    Console.WriteLine(value);
}





















