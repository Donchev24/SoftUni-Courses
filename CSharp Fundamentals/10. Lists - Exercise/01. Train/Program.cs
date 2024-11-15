namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            List<string> input = Console.ReadLine().Split().ToList();

            while (input[0] != "end")
            {
                if (input.Count == 2)
                {
                    wagons.Add(int.Parse(input[1]));
                }
                else
                {
                    int passengers = int.Parse(input[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengers <= maxCapacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }

                input = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
