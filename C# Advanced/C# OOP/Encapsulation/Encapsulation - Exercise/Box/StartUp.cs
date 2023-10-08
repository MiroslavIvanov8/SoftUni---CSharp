namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            List<Box> boxes = new List<Box>();
            try
            { 
                Box box = new(length, width, height);
                boxes.Add(box);
            }   
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           foreach(var box in boxes)
                Console.WriteLine(box.ToString());
        }
    }
}