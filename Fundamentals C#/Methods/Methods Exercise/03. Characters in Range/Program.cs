namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());
            char token ;
            if (char2 < char1)
            {
                token = char1;
                char1 = char2;
                char2 = token;                
            }
            PrintOnConsole(char1, char2);
                
        }
        static void PrintOnConsole(char char1, char char2)
        {
            for(int i=char1+1;i<char2;i++)
            {
                Console.WriteLine((char)i);
            }
        }
    }
}