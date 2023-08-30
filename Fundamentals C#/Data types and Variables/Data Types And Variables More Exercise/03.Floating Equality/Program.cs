double firstNum = double.Parse(Console.ReadLine());
double secondNum = double.Parse(Console.ReadLine());
double diff = firstNum - secondNum;
diff = Math.Abs(diff);
if (diff<= 0.000001)
{
    Console.WriteLine("True");
}
else
    Console.WriteLine("False");