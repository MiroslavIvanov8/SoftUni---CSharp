namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> normalGuests = new HashSet<string>();
            HashSet<string> VIP = new HashSet<string>();
            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (input.Length == 8)
                {
                    if (char.IsDigit(input[0]))
                    {
                        VIP.Add(input);
                    }
                    else
                    {
                        normalGuests.Add(input);
                    }
                }
            }
            string guestToCome = string.Empty;
            while ((guestToCome = Console.ReadLine()) != "END")
            {
                if(VIP.Contains(guestToCome))
                    VIP.Remove(guestToCome);
                else if (normalGuests.Contains(guestToCome))
                    normalGuests.Remove(guestToCome);
            }
            Console.WriteLine(VIP.Count + normalGuests.Count);
            foreach (string guest in VIP)
                Console.WriteLine(guest);
            foreach(string guest in normalGuests)
                Console.WriteLine(guest);
        }
    }
}