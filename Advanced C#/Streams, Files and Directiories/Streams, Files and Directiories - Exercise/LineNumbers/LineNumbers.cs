namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
                StringBuilder sb = new StringBuilder();
                string[] lines = File.ReadAllLines(inputFilePath);
            int lineNumber = 1;
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    
                    int letterCount = CountLetters(line);
                    int markCount = CountMarks(line);

                    sb.AppendLine($"Line {lineNumber++}:{line} ({letterCount})({markCount})");

                    
                }
            File.WriteAllText(outputFilePath,sb.ToString());

        }
        private static int CountLetters(string line)
        {
            string text = line;
            int count = 0;

            foreach (char ch in text)
            {
                if(char.IsLetter(ch))
                    count++;
            }
            return count;
        }
        private static int CountMarks(string line)
        {
            string text = line;
            char[] symbols = { '-','?','!','.',',','\''};
            int count = 0;
            foreach (char symbol in symbols)
            {
                foreach (char ch in text)
                {
                    if(symbol==ch)
                        count++;
                }
            }
            return count;
            
        }

        
    }
}
