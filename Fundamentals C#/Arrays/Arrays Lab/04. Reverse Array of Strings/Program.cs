string[] inputString = Console.ReadLine().Split().ToArray();
string[] reversedString = inputString.Reverse().ToArray();
for (int i = 0; i < reversedString.Length; i++)
{
    Console.Write(reversedString[i]+" ");
}

   
