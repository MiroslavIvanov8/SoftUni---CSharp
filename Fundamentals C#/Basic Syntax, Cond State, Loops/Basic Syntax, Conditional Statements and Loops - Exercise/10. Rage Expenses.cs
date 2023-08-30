
double lostGames = double.Parse(Console.ReadLine());
double headsetPr = double.Parse(Console.ReadLine());
double mousePr = double.Parse(Console.ReadLine());
double keyboardPr = double.Parse(Console.ReadLine());
double displayPr = double.Parse(Console.ReadLine());

double headsetCnt = 0;
double mouseCnt = 0;
double keyboardCnt = 0;
double displayCnt = 0;

for (int i = 1; i <= lostGames; i++)
{
    if (i % 2 == 0)
    {
        headsetCnt++;
    }
    if(i%3== 0)
    {
        mouseCnt++;
    }
    if(i%2==0 && i%3==0) 
    {
        keyboardCnt++;
        if (keyboardCnt % 2 == 0 && keyboardCnt != 0)
        {
            displayCnt++;
        }
    }
    
}
double priceAll = headsetCnt*headsetPr + mouseCnt*mousePr + keyboardCnt*keyboardPr + displayCnt*displayPr;
Console.WriteLine($"Rage expenses: {priceAll:f2} lv.");