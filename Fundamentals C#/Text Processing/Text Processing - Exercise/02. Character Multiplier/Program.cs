namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string input1 = input[0];
            string input2 = input[1];

            Multiply(input1, input2);

        }
        public static void Multiply(string input1, string input2)
        {
            input1.ToCharArray();
            input2.ToCharArray();
            int sum = 0;
            if (input1.Length > input2.Length)
            {
                for (int i = 0; i < input2.Length; i++)
                {
                    sum += input1[i] * input2[i];
                }
                for (int i = input2.Length; i < input1.Length; i++)
                {
                    sum += input1[i];
                }
            }
            else
            {
                for (int i = 0; i < input1.Length; i++)
                {
                    sum += input1[i] * input2[i];
                }
                for (int i = input1.Length; i < input2.Length; i++)
                {
                    sum += input2[i];
                }
            }
            Console.WriteLine(sum);
        }
    }   

}