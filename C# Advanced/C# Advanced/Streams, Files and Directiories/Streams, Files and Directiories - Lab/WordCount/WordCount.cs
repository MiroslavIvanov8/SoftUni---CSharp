namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader textReader = new StreamReader(textFilePath))
            { 
            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        Dictionary<string, int> wordCount = new();

                        foreach (string word in reader.ReadLine().Split(" "))
                        {
                            wordCount.Add(word, 0);
                        }

                        while (!textReader.EndOfStream)
                        {
                            string[] currLine = textReader.ReadLine().ToLower().Split(new string[] {" ",".","-","," },StringSplitOptions.RemoveEmptyEntries);
                            foreach (string text in currLine)
                                if (wordCount.ContainsKey(text.ToLower()))
                                    wordCount[text.ToLower()]++;
                        }

                        foreach (var kvp in wordCount.OrderByDescending(x=>x.Value))
                            writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                    }
                }

            }
        }
    }
}
