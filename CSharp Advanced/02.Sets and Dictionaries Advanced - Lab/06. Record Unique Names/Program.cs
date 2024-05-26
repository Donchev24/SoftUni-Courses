namespace _06._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string input = string.Empty;

            HashSet<string> parkedCars = new();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] parkingTokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = parkingTokens[0];
                string carNumber = parkingTokens[1];

                if (parkingTokens[0] == "IN")
                {
                    if (!parkedCars.Contains(carNumber))
                    {
                        parkedCars.Add(carNumber);
                    }
                }

                else
                {
                    if (parkedCars.Contains(carNumber))
                    {
                        parkedCars.Remove(carNumber);
                    }
                }
            }

            if (parkedCars.Any())
            {
                foreach (var car in parkedCars)
                {
                    Console.WriteLine($"{car}");
                }

            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }

        }
     }
  }
