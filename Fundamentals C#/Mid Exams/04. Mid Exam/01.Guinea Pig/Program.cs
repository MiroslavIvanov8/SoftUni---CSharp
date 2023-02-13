using System;
using System.Diagnostics.Tracing;
using System.Net.Http.Headers;

namespace _01.Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine())*1000;
            double hay = double.Parse(Console.ReadLine())*1000;
            double cover = double.Parse(Console.ReadLine()) * 1000;
            double weight = double.Parse(Console.ReadLine()) * 1000;
            bool resourses = true;
            int counter = 0;
            while (counter<30)
            {
                counter++;

                if (food<=0 || hay<=0||cover<=0)
                {
                    resourses= false;
                    break;
                }
                food -= 300;
                if(counter%2==0)
                {
                    hay -=food * 0.05;
                }
                if (counter % 3 == 0)
                {
                    cover -= weight / 3;
                }
                
            }

            if (!resourses)
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
            else
            {
                food /= 1000;
                hay/= 1000;
                cover/= 1000;
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
            }
        }
    }
}
