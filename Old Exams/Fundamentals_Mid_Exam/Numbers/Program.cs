namespace Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> values = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = values
                .Where(x => x > values
                .Average())
                .OrderByDescending(x => x)
                .Take(5)
                .ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
