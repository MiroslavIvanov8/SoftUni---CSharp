namespace EvenLines
{
    using System;
    using System.IO;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader reader = new(inputFilePath);
            {
                StringBuilder sb = new StringBuilder();
                int count = 0;
                string line = string.Empty;

                while (line != null)
                {
                    line = reader.ReadLine();
                    
                    if (count % 2 == 0)
                    {
                        string replaceSymbols = ReplaceSymbols(line);
                        string reversedLine = ReverseLine(replaceSymbols);
                        sb.AppendLine(reversedLine);
                    }
                    count++;
                }                
                return sb.ToString();
            }
            
            
        }

        private static string ReverseLine(string replaceSymbols)
        {
            StringBuilder sb = new();
            string[] text = replaceSymbols.Split(" ",StringSplitOptions.RemoveEmptyEntries) ;
            for (int i = text.Length-1; i >= 0; i--)
            {
                sb.Append($"{text[i]} ");
            }
            return sb.ToString();

        } 

        private static string ReplaceSymbols(string line)
        {
            StringBuilder sb = new StringBuilder(line);

            char[] symbols = { '-', ',','.','!','?' };

            foreach (char ch in symbols)
            {
                sb = sb.Replace(ch, '@'); 
            }

            return sb.ToString();
        }
    }
}
