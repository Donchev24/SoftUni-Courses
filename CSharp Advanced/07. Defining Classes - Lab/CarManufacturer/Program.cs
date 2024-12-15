using System.Reflection;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "No")
            {
                Tire[] currentTiresInfo = new Tire[4];

                int tireYear = 0;
                double tirePressure = 0;

                int counter = -1;

                for (int i = 0; i < command.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        tireYear = int.Parse(command[i]);
                    }
                    else
                    {
                        counter++;

                        tirePressure = double.Parse(command[i]);

                        Tire tire = new Tire(tireYear, tirePressure);
                        currentTiresInfo[counter] = tire;
                    }
                }

                tiresList.Add(currentTiresInfo);

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

    

            List<Engine> engineList = new List<Engine>();

            string[] command2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command2[0] != "Engines")
            {
                int horsePower = 0;
                double cubicCapacity = 0;

                for (int i = 0; i < command2.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        horsePower = int.Parse(command2[i]);
                    }
                    else
                    {
                        cubicCapacity = double.Parse(command2[i]);
                    }
                }

                Engine engine = new Engine(horsePower, cubicCapacity);
                engineList.Add(engine);

                command2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }


            List<Car> carList = new List<Car>();

            string[] command3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


            while (command3[0] != "Show")
            {
                string make = command3[0];
                string model = command3[1];
                int year = int.Parse(command3[2]);
                double fuelQuantity = double.Parse(command3[3]);
                double fuelConsumption = double.Parse(command3[4]);
                Engine engine = engineList[int.Parse(command3[5])];
                Tire[] tires = tiresList[int.Parse(command3[6])];

                Car car = new Car(make,model,year,fuelQuantity, fuelConsumption, engine, tires);

                carList.Add(car);

                //{ make}
                //{ model}
                //{ year}
                //{ fuelQuantity}
                //{ fuelConsumption}
                //{ engineIndex}
                //{ tiresIndex}

                command3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }


            IEnumerable<Car> filteredCars = carList.Where(car => car.Year >= 2017 &&
                                                      car.Engine.HorsePower > 330 &&
                                                      car.Tires.Sum(t => t.Pressure) > 9 && car.Tires.Sum(t => t.Pressure) < 10);

            foreach (Car car in filteredCars)
            {
                car.Drive();
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
