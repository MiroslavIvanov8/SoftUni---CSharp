namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            IStationary stationaryPhone = new Stationaryphone();
            ISmartphone smartPhone = new Smartphone();

            List<string> numbers = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
            List<string> urls = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());

            foreach (string number in numbers)
            {
                
                if (number.Length == 10)
                {
                    smartPhone.Calling(number);
                }
                else
                {
                    stationaryPhone.Dialing(number);
                }
            }

            foreach (string url in urls)
            {
                
                smartPhone.Browsing(url);
            }
        }
    }
}