﻿

using System.Numerics;
BigInteger maxValue = 0;
int number = int.Parse(Console.ReadLine());
int bestTime=0;
int bestSnow = 0;
int bestQuality = 0;

for (int i = 0; i < number; i++)
{
    
    int snow = int.Parse(Console.ReadLine());
    int time = int.Parse(Console.ReadLine());
    int quality = int.Parse(Console.ReadLine());
    BigInteger bestValue = BigInteger.Pow((snow / time), quality);
    if (bestValue > maxValue)
    {
        maxValue = bestValue;
        bestSnow = snow;
        bestQuality = quality;
        bestTime = time;
    }
}
Console.WriteLine($"{bestSnow} : {bestTime} = {maxValue} ({bestQuality})");

