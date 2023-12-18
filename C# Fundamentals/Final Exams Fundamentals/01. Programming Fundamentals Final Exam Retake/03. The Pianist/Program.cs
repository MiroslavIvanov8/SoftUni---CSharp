namespace _03._The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var pianoPieces = new Dictionary<string, Dictionary<string, string>>();
            string input = string.Empty;
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                string[] pieceInfo = input.Split("|");
                string piece = pieceInfo[0];
                string composer = pieceInfo[1];
                string key = pieceInfo[2];
                if (!pianoPieces.ContainsKey(piece))
                {
                    pianoPieces.Add(piece, new Dictionary<string, string>());
                    pianoPieces[piece].Add(composer, key);
                }
                else
                    continue;

            }
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] commandArgs = input.Split("|");
                if (commandArgs[0] == "Add")
                {
                    string piece = commandArgs[1];
                    string composer = commandArgs[2];
                    string key = commandArgs[3];
                    if (!pianoPieces.ContainsKey(piece))
                    {
                        pianoPieces.Add(piece, new Dictionary<string, string>());
                        pianoPieces[piece].Add(composer, key);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (commandArgs[0] == "Remove")
                {
                    string piece = commandArgs[1];
                    if (!pianoPieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                    else
                    {
                        pianoPieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }

                }
                else if (commandArgs[0] == "ChangeKey")
                {
                    string piece = commandArgs[1];
                    string newKey = commandArgs[2];
                    if (!pianoPieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                    else
                    {
                        //Dictionary<string, string> compositor = pianoPieces[piece];
                        //foreach(var comp in compositor)
                        //{                            
                        //    compositor[comp.Key] = newKey;  
                        //}                        
                        
                        string comp2 = pianoPieces[piece].Keys.First();
                        pianoPieces[piece][comp2] = newKey;                        
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                         
                    }
                }
            }
            foreach(var piece in pianoPieces)
            {
                foreach (var innerPair in piece.Value)
                    Console.WriteLine($"{piece.Key} -> Composer: {innerPair.Key}, Key: {innerPair.Value}");
            }
        }
    }
}