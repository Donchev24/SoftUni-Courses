namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkedCars = new();

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "END")
            {
                string direction = input[0];
                string registration = input[1];

                if (direction == "IN")
                {
                    parkedCars.Add(registration);
                }
                else
                {
                    parkedCars.Remove(registration);
                }

                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (parkedCars.Any())
            {
                foreach (string car in parkedCars)
                {
                    Console.WriteLine(car); 
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
