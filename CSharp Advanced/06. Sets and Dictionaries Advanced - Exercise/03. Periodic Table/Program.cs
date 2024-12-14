namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> elements = new();

            for (int i = 0; i < n; i++)
            {
                string[] currentElement = Console.ReadLine().Split();

                foreach (string element in currentElement)
                {
                    elements.Add(element);
                }
            }

            Console.WriteLine($"{string.Join(" ", elements.OrderBy(e => e))}");
        }
    }
}
