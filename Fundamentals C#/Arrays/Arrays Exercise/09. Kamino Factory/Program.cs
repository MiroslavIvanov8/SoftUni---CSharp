

using System.Diagnostics.Metrics;

int arrayLenght = int.Parse(Console.ReadLine());
int[] currentLongestSequence = new int[arrayLenght];
int currentSequenceLength = 0;
int currentStartingIndex = 0;
int currentSum = 0;
int dnaNumber = 0;
int counter = 0;
string input;
while ((input = Console.ReadLine()) !="Clone them!")

{
    counter++;
    int[] dnaArrayInt = input.Split("!", StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToArray();
    int length = 0;
    foreach (var item in dnaArrayInt)
    {
        if (item == 1)
        {
            length++;
        }
        else if(item == 0 && length>0)
        {
            break;  
        }        
    }

    int startingIndex = Array.IndexOf(dnaArrayInt, 1);
    int sum = dnaArrayInt.Sum();
    if (length > currentSequenceLength || length == currentSequenceLength && currentStartingIndex > startingIndex
        || length == currentStartingIndex && currentStartingIndex == startingIndex && sum > currentSum)
    {
        currentLongestSequence = dnaArrayInt;
        currentSequenceLength = length;
        currentStartingIndex = startingIndex;
        currentSum= sum;
        dnaNumber = counter;
    }
}
Console.WriteLine($"Best DNA sample {dnaNumber} with sum: {currentSum}.");
Console.WriteLine(string.Join(" ", currentLongestSequence));