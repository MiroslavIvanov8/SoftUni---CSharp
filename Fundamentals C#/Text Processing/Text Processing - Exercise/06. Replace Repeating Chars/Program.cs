namespace _06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] charArr = input.ToCharArray();
            List<char> charList = charArr.ToList();
            for (int i = 0; i < charList.Count; i++)
            {
                if (i == charList.Count-1)
                    break;
                if (charList[i] == charList[i + 1])
                {
                    charList.RemoveAt(i);
                    i--;
                    
                }
                
            }
            Console.WriteLine(string.Join("",charList));
        
        }
    }
}