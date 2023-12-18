string[] weekdays = {"Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday" };
int day = int.Parse(Console.ReadLine());
if(day<=7 && day>=1)
Console.WriteLine(weekdays[day-1]);
else   
    Console.WriteLine("Invalid day!");
    

