namespace RawData
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();   
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                int engineSpeed = int .Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeigth = int.Parse(carInfo[3]);
                string cargoType = carInfo[4]; 

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeigth);
                Tire[] tires = new Tire[4];
                int tireCnt = 0;

                for (int j = 5; j < carInfo.Length; j++)
                {
                    if (j % 2 == 0)
                        continue;
                    int tireAge = int.Parse(carInfo[j+1]);
                    double tirePressure = double.Parse(carInfo[j]);
                    Tire tire = new Tire(tireAge, tirePressure);
                    tires[tireCnt] = tire;
                    tireCnt++;
                }
                Car car = new Car(model,engine,cargo, tires);
                cars.Add(car);
            }
            string type = Console.ReadLine();

            //List<Car> filteredCars = cars.Where(x => x.Cargo.Type == type && x.Tires.Any(t=>t.Pressure<1)).ToList();
            List<Car> filteredCars = cars.Where(x => x.Cargo.Type == type).ToList();
            foreach (var car in filteredCars)
                if (car.Cargo.Type == "fragile")
                {
                    foreach (Tire tire in car.Tires)
                        if (tire.Pressure < 1)
                        {
                            Console.WriteLine(car.Model);
                            break;
                        }
                }
                else if (car.Cargo.Type == "flammable" && car.Engine.Power>250)
                {
                    Console.WriteLine(car.Model);   
                }

        }
    }
}