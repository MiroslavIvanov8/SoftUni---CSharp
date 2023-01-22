int key = int.Parse(Console.ReadLine());
int lines = int.Parse(Console.ReadLine());
char[] arr = new char[lines];
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
for (int i = 0; i < arr.Length; i++)
{
    
    Console.Write(arr[i]);
}








