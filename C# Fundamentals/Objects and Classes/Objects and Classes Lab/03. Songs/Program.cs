using System.ComponentModel;

namespace _03._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("_");
                string type = input[0];
                string name = input[1];
                string time = input[2];

                Song song = new Song();
                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }
            string searchedType = Console.ReadLine();

            if (searchedType == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == searchedType)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }

        class Song
        {
            public string TypeList { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }
        }
    }
}