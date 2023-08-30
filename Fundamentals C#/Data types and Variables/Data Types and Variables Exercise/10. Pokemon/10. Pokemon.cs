int N = int.Parse(Console.ReadLine());
decimal N2 = N*0.50m;
int M = int.Parse(Console.ReadLine());
int Y = int.Parse(Console.ReadLine());
int pokeCnt = 0;

while (N >= M)
{
    N -= M;
    pokeCnt++;  
    if (N == N2)
    {
        if(Y!=0) 
        N /= Y;
       
    }
}
Console.WriteLine(N);
Console.WriteLine(pokeCnt);
