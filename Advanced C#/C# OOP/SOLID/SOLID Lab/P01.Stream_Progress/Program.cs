using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            File music = new Music("Weeknd", "After Hours", 60, 200);
            StreamProgressInfo streamProgressInfo = new StreamProgressInfo(music);
            Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());

            File picture = new Picture("KEK","myself", 10, 11);
            StreamProgressInfo newStream = new StreamProgressInfo(picture);

        }
    }
}
