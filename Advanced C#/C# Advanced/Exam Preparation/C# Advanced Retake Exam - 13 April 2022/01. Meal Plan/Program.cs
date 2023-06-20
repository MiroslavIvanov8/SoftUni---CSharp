using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> days = new(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int mealCounter = 0;
            while (true)
            {
                if (days.Count == 0)
                    break;
                if (meals.Count == 0)
                    break;

                string currMeal = meals.Dequeue();
                mealCounter++;
                int currDay = days.Pop();
                int mealCalories = 0;
                switch (currMeal)
                {
                    case "salad":
                        mealCalories = 350;
                        break;
                    case "soup":
                        mealCalories = 490;
                        break;
                    case "pasta":
                        mealCalories = 680;
                        break;
                    case "steak":
                        mealCalories = 790;
                        break;
                }
                currDay -= mealCalories;
                if (currDay < 0)
                {
                    if (days.Count == 0)
                        break;
                    currDay = days.Pop() + currDay;
                    days.Push(currDay);
                }
                else
                {
                    days.Push(currDay);
                }
                
            }

            if (!meals.Any())
            {
                Console.WriteLine($"John had {mealCounter} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", days)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealCounter} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ",meals)}.");
            }
        }
    }
}


