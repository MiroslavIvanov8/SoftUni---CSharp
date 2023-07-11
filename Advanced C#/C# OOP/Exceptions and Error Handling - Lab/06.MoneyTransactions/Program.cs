namespace _06.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, double> accountBalance = new();
            foreach (string data in info)
            {
                string[] dataInfo = data.Split("-", StringSplitOptions.RemoveEmptyEntries);

                int number = int.Parse(dataInfo[0]);
                double balance = double.Parse(dataInfo[1]);

                accountBalance[number] = balance;
            }
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArgs[0];
                int number = int.Parse(cmdArgs[1]);
                double value = double.Parse(cmdArgs[2]);

                try
                {
                    if (command == "Deposit")
                    {
                        accountBalance[number] += value;
                        Console.WriteLine($"Account {number} has new balance: {accountBalance[number]:f2}");
                    }

                    else if (command == "Withdraw")
                    {
                        if (accountBalance[number] - value < 0)
                        {
                            throw new ArithmeticException("Insufficient balance!");
                        }
                        accountBalance[number] -= value;
                        Console.WriteLine($"Account {number} has new balance: {accountBalance[number]:f2}");
                    }

                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                catch (ArithmeticException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (System.Collections.Generic.KeyNotFoundException)
                {
                    Console.WriteLine("Invalid account!");
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command"); 
                }
            }
        }
    }
}