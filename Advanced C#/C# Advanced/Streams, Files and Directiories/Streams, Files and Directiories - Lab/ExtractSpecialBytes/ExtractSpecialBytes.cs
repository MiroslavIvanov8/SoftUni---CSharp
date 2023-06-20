namespace ExtractSpecialBytes
{
    using System;
    using System.IO;
    using System.Text;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png"; 
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (FileStream streamOpen = new FileStream(binaryFilePath,FileMode.Open))
            {
                using (FileStream streamCreate = new FileStream(outputPath, FileMode.Create))
                {
                    
                }
                
                           
            }
        }
    }
}
