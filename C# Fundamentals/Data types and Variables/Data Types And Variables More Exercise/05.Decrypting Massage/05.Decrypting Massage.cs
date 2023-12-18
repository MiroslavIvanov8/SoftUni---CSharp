int key = int.Parse(Console.ReadLine());
int lines = int.Parse(Console.ReadLine());
int[] arr = new int[lines];
for (int i = 0; i < lines; i++)
{
    char symbol = char.Parse(Console.ReadLine());
    int letter = symbol + key;
    //Console.Write($"{(char)letter}");
    arr[i]+=(char)letter;
}

//foreach (char ch in arr)
//{
//    Console.Write("{0}", ch);
//}
for (int i = 0; i < arr.Length-1; i++)
{
    
    Console.Write((char)arr[i]);
}








