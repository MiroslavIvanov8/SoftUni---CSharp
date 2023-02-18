namespace _04._Mixed_up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 =Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> numbers2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int rangeNumber1 = 0;
            int rangeNumber2 = 0;
            bool isBiggerOne= true;
            if (numbers1.Count > numbers2.Count)
            {
                rangeNumber1 = numbers1[numbers1.Count-1];
                rangeNumber2 = numbers1[numbers1.Count - 2];
                numbers1.RemoveAt(numbers1.Count-1);
                numbers1.RemoveAt(numbers1.Count-1);
                
            }
            else if (numbers2.Count > numbers1.Count)
            {
                rangeNumber1 = numbers2[0];
                rangeNumber2 = numbers2[1];
                numbers2.RemoveAt(0);
                numbers2.RemoveAt(0);
                
            }
              int [] mergedLists= new int[numbers2.Count+numbers1.Count];
            int k = 0;
            for (int i = 0; i < numbers1.Count; i++)
            {              
                   
                    mergedLists[i + k] = numbers1[i];
                k++;                                   
            }
            int j = 1;
            for (int i = numbers2.Count-1; i>=0; i--)
            {
                mergedLists[j] = numbers2[i];
                j += 2;
            }

            List<int> inRangeNumbers = new List<int>();

            if(rangeNumber1>rangeNumber2)
                isBiggerOne= true;
            else
                isBiggerOne= false;

            for (int i = 0; i < mergedLists.Length; i++)
            {
                if (isBiggerOne)
                {
                    if (mergedLists[i] < rangeNumber1 && mergedLists[i] > rangeNumber2)
                        inRangeNumbers.Add(mergedLists[i]);
                }
                else
                {
                    if (mergedLists[i] > rangeNumber1 && mergedLists[i] < rangeNumber2)
                        inRangeNumbers.Add(mergedLists[i]);
                }
            }
            inRangeNumbers.Sort();
            Console.WriteLine(string.Join(" ", inRangeNumbers));
        }
    }
}