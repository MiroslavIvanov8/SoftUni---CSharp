namespace Easy.RomanToInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RomanToInt("MCMXCIV"));
        }

        public static int RomanToInt(string str)
        {
            int sum = 0;

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                char next = '0';

                if (i + 1 < str.Length)
                {
                   next = str[i + 1];
                }


                {
                    if (ch == 'I')
                    {
                        if (next == 'V' || next == 'X')
                        {
                            if (next == 'V')
                            {
                                sum += 4;
                                i++;
                            }
                            else if (next == 'X')
                            {
                                sum += 9;
                                i++;
                            }
                        }
                        else
                        {
                            sum += 1;
                        }

                    }
                    else if (ch == 'V')
                    {
                        sum += 5;
                    }
                    else if (ch == 'X')
                    {
                        if (next == 'L' || next == 'C')
                        {
                            if (next == 'L')
                            {
                                sum += 40;
                                i++;
                            }
                            else if (next == 'C')
                            {
                                sum += 90;
                                i++;
                            }
                        }
                        else
                        {
                            sum += 10;
                        }
                    }
                    else if (ch == 'L')
                    {
                        sum += 50;
                    }
                    else if (ch == 'C')
                    {
                        if (next == 'D' || next == 'M')
                        {
                            if (next == 'D')
                            {
                                sum += 400;
                                i++;
                            }
                            else if (next == 'M')
                            {
                                sum += 900;
                                i++;
                            }
                        }
                        else
                        {
                            sum += 100;
                        }
                    }
                    else if (ch == 'D')
                    {
                        sum += 500;
                    }
                    else if (ch == 'M')
                    {
                        sum += 1000;
                    }
                }
            }

            return sum;
        }
    }
}
