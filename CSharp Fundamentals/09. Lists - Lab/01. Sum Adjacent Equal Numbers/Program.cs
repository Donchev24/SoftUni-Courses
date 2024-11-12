namespace _01._Sum_Adjacent_Equal_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                double current = numbers[i];
                double next = numbers[i + 1];

                if (current == next)
                {
                    numbers[i] = current + next;
                    numbers.Remove(next);

                    i = 0 - 1;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
