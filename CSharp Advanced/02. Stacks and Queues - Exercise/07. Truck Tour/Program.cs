namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());

            Queue<(int, int)> petrolKmPair = new();

            for (int i = 0; i < pumps; i++)
            {
                int[] petrolPumps = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                petrolKmPair.Enqueue((petrolPumps[0], petrolPumps[1]));

            }

            int startIndex = 0;

            while (true)
            {
                int totalPetrol = 0;

                foreach (var item in petrolKmPair)
                {
                    totalPetrol += item.Item1;
                    int km = item.Item2;

                    totalPetrol -= km;

                    if (totalPetrol < 0)
                    {
                        break;
                    }
                }

                if (totalPetrol < 0)
                {
                    startIndex++;
                    petrolKmPair.Enqueue(petrolKmPair.Dequeue());
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(startIndex);
        }
    }
}
