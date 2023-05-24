Queue<string> songs = new(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries));
while (songs.Any())
{
    string[] command = Console.ReadLine().Split();
    if (command[0] =="Play"|| command[0] == "Show")
    {
        if (command[0] == "Play")
        {  
            songs.Dequeue();
        }
        else if (command[0] == "Show")
            Console.WriteLine(string.Join(", ", songs));
    }
    else
    {
        string songToAdd = string.Join(" ",command.Skip(1));
        // string song = string.Joint(" ", command[1..]);
        if (songs.Contains(songToAdd))
        {
            Console.WriteLine($"{songToAdd} is already contained!");
            continue;
        }
        else if (!songs.Contains(songToAdd))
            songs.Enqueue(songToAdd);
    }
}
    Console.WriteLine("No more songs!");
