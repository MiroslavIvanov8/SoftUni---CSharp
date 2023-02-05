int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray(); //1 1 1 2 3 1 3 3
int sequence = 0;
int BestSequence = 0;
int sequenceNumber = 0;
int bestNumber = 0;
for (int i = 0; i < inputArray.Length-1; i++)
{
    if (inputArray[i] != inputArray[i + 1])
    {
        sequence = 0;
        continue;
    }
    if (inputArray[i] == inputArray[i + 1])
    {
        sequence++;
        sequenceNumber = inputArray[i];
    }

    if (sequence > BestSequence)
    {
        BestSequence = sequence;
        bestNumber = inputArray[i];
    }

    
}

for (int i = 0; i <= BestSequence; i++)
{
    Console.Write(bestNumber+ " ");
}
