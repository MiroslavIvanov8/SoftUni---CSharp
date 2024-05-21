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

            int leastSweetCookie = queue.First();
            int steps = 0;

            while (leastSweetCookie < minSweetness && queue.Count > 1)
            {
                leastSweetCookie = queue.RemoveFirst();
                int secondMinSweetCookie = queue.RemoveFirst();

                int newCookie = leastSweetCookie + 2 * secondMinSweetCookie;
                queue.Add(newCookie);
                steps++;

                leastSweetCookie = queue.First();
            }

            return leastSweetCookie < minSweetness ? -1 : steps;
        }
    }
}
