namespace P01.Stream_Progress
{
    public class Music : File
    {
        public Music(string artist, string album, int length, int bytesSent) : base(artist, length, bytesSent)
        {
            Artist = artist;
            Album = album;
        }


        public string Name { get; }
        public string Artist { get; }
        public string Album { get; }

    }
}
