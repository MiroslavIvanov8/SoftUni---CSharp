using System.Collections;

int greenLightWindow = int.Parse(Console.ReadLine());
int freeWindow = int.Parse(Console.ReadLine());
string car = string.Empty;
Queue<string> traffic = new();

int carsPassed = 0;
while ((car = Console.ReadLine()) != "END")
{

    if (car != "green")
    {
        traffic.Enqueue(car);
        continue;
      
    }
    else if (car == "green")
    {
        int currentGreenLight = greenLightWindow;
        while (currentGreenLight > 0 && traffic.Any())
        {
            string currentCar = traffic.Dequeue();

            if (currentGreenLight >= currentCar.Length)
            {
                carsPassed++;
                currentGreenLight -= currentCar.Length;
                continue;
            }

            if(currentGreenLight + freeWindow - currentCar.Length>=0)
            {
                carsPassed++;
                currentGreenLight -= currentCar.Length;
                continue;
            }
            int hittedChar = currentGreenLight + freeWindow;

            Console.WriteLine("A crash happened!");
            Console.WriteLine($"{currentCar} was hit at {currentCar[hittedChar]}.");

            return;
        }        
    }    
}
Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{carsPassed} total cars passed the crossroads.");

