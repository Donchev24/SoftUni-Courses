namespace _02._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                int firstElement = numbers[i];
                int lastElement = numbers[numbers.Count - 1 - i];

                result.Add(firstElement + lastElement);
            }

            if (numbers.Count % 2 != 0)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i == numbers.Count / 2)
                    {
                        result.Add(numbers[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
