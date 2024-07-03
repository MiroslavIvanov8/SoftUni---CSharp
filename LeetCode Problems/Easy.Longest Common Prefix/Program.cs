using System.Linq;

namespace Easy.Longest_Common_Prefix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strs = new string[] { "flower", "flow", "flight" };
            Console.WriteLine(FindLongestCommonPrefix(strs));
        }

        public static string FindLongestCommonPrefix(string[] strs) 
        {
            int size = strs.Length;

            /* if size is 0, return empty string */
            if (size == 0)
                return "";

            if (size == 1)
                return strs[0];

            Array.Sort(strs);

            int min = Math.Min(strs[0].Length, strs[^1].Length);
            int i = 0;
            while (i < min && strs[0][i] == strs[^1][i])
                i++;

            string pre = strs[0].Substring(i);
            return pre;

        }
    }
}
