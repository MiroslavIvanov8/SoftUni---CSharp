namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            long bytes = 0;

            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);

            FileInfo[] files = dirInfo.GetFiles();
            foreach (var file in files)
            {
                bytes += file.Length;
            }
            using (StreamWriter stream = new StreamWriter(outputFilePath))
            {
                stream.Write($"{bytes} KB");
            }


        }
    }
}
