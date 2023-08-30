using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;

List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
string input ;
while ((input = Console.ReadLine())!= "end")
{

    string[] commandArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    
    if (commandArgs[0] == "Delete")
    {
        int element = int.Parse(commandArgs[1]);
        numbers.RemoveAll(x => x == element);
    }
    else if (commandArgs[0] == "Insert")
    {
        
        int element = int.Parse(commandArgs[1]);
        int index = int.Parse(commandArgs[2]);
        if (index >= numbers.Count || index < 0)
            continue;
        numbers.Insert(index, element);
    }
    
}
Console.WriteLine(string.Join(" ", numbers));

