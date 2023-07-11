namespace _3.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            string[] validFaces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] validSuit = new string[] { "S", "H", "D", "C" };

            List<Card> cards = new();
            foreach (var pair in input)
            {
                string[] cardInfo = pair.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string face = cardInfo[0];
                string suit = cardInfo[1];

                try
                {
                    if (!validFaces.Any(f => f == face) || !validSuit.Any(s => s == suit))
                        throw new ArgumentException("Invalid card!");

                    Card card = new Card(face, suit);

                    cards.Add(card);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }

    public class Card
    {
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face { get; set; }
        public string Suit { get; set; }
        public override string ToString()
        {
            switch (Suit)
            {
                case "S":
                    Suit = "\u2660";
                    break;
                case "H":
                    Suit = "\u2665";
                    break;
                case "D":
                    Suit = "\u2666";
                    break;
                case "C":
                    Suit = "\u2663";
                    break;
                                   
            }
            return $"[{Face}{Suit}]";
        }
    }
}