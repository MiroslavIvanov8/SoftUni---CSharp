namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isCharsEnough = CharCountCheck(password);
            bool onlyLettersAndDigits = LetterAndDigitCheck(password);
            bool atleast2Digits = Atleast2DigitsCheck(password);

            if (isCharsEnough && onlyLettersAndDigits && atleast2Digits)
                Console.WriteLine("Password is valid");
            if (isCharsEnough == false)
                Console.WriteLine("Password must be between 6 and 10 characters");
            if (onlyLettersAndDigits == false)
                Console.WriteLine("Password must consist only of letters and digits");
            if (atleast2Digits == false)
                Console.WriteLine("Password must have at least 2 digits");
        }

        static bool CharCountCheck(string password)
        {
            if(password.Length>=6 && password.Length<=10)
                return true;
            else 
                return false;
        }
        static bool LetterAndDigitCheck(string password)
        {
            bool onlyLettersAndDigits = true;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57 || password[i] >= 65 && password[i] <= 90 || password[i] >= 97 && password[i] <= 122)
                    onlyLettersAndDigits = true;
                else
                {
                    return false;
                }
            }
            if (!onlyLettersAndDigits)
                return false;
            else
                return true;
        }
        static bool Atleast2DigitsCheck(string password)
        {
            int digitCount = 0;
            for(int i=0;i<password.Length;i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                    digitCount++;               
            }
            if(digitCount>=2)
                return true;
            else 
                return false;
        }
    }
}