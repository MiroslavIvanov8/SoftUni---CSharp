namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader firstReader = new StreamReader(firstInputFilePath))
            {
                using (StreamReader secondReader = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        if (firstReader.BaseStream.Length >= secondReader.BaseStream.Length)
                        {
                            while (!secondReader.EndOfStream)
                            {
                                writer.WriteLine(firstReader.ReadLine());
                                writer.WriteLine(secondReader.ReadLine());
                            }

                            while (!firstReader.EndOfStream)
                            {
                                writer.WriteLine(firstReader.ReadLine());
                            }
                        }

                        else if (firstReader.BaseStream.Length < secondReader.BaseStream.Length)
                        {
                            while (!firstReader.EndOfStream)
                            {
                                writer.WriteLine(firstReader.ReadLine());
                                writer.WriteLine(secondReader.ReadLine());
                            }

                            while (!secondReader.EndOfStream)
                            {
                                writer.WriteLine(secondReader.ReadLine());
                            }
                        }
                    }
                }
            }
        }
    }
}
