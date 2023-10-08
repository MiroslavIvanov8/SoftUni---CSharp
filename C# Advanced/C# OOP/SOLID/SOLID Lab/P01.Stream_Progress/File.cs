namespace P01.Stream_Progress
{
    public class File 
    {

        public File(string name ,int length, int bytesSent)
        {
            Name = name;
            Length = length;
            BytesSent = bytesSent;
        }

        public string Name { get; }
        public int Length { get; set; }

        public int BytesSent { get; set; }

        
    }
}
