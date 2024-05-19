using System;
using System.Linq;
using _03.MinHeap;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            var queue = new OrderedBag<int>();
            queue.AddMany(cookies);
            int currentMinSweetness = queue[0];
            int steps = 0;

            while (currentMinSweetness < minSweetness && queue.Count > 1)
            {
                int leastSweetCookie = queue.RemoveFirst();
                int secondLeastCookie = queue.RemoveFirst();

                int newCookie = leastSweetCookie + (2 * secondLeastCookie);

                queue.Add(newCookie);
                currentMinSweetness = queue.First();
                steps++;
            }

            return currentMinSweetness < minSweetness ? -1 : steps;
        }
    }
}
