


   //  1 1 3 3
   //i[0]                           i[1]
   //left sum=0                     leftsum = i[0]
   //rightsum =i[1] +i[2]+ if[3]   right sum = i[2]+i[3]



int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
bool evenSum=false;
int leftSum = 0;
int rightSum = 0;
int i;
for (i = 0; i < inputArray.Length; i++)
{
    rightSum = 0;
    leftSum=0;
    if (i == 0)
        leftSum = 0;
    if (i == inputArray.Length)
    {
        rightSum = 0;
    }
    for (int j = i+1; j < inputArray.Length; j++)
    {
        rightSum+= inputArray[j];
    }
    for (int k = i-1; k >= 0;k--)
    {
        leftSum += inputArray[k];
    }
    if (leftSum == rightSum)
    {
        evenSum= true;
        break;
    }
    
}
if (evenSum)
    Console.Write($"At [{i}]");
else
    Console.WriteLine("no");
