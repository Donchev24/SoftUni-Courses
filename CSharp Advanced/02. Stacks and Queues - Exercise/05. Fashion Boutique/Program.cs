namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> values = new Stack<int>(input);

            int rackCapacity = int.Parse(Console.ReadLine());

            int currentRackCap = 0;

            int racks = 1;

            while (values.Any())
            {
                int currentValue = values.Pop();

                if (currentValue + currentRackCap <= rackCapacity)
                {
                    currentRackCap += currentValue;
                }
                else
                {
                    racks++;
                    currentRackCap = currentValue;
                }
            }

            Console.WriteLine(racks);

        }
    }
}
