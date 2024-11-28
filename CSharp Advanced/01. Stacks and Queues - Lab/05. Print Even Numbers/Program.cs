using System.Text;

namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            Queue<int> evenNumbers = new Queue<int>();

            while (queue.Any())
            {
                int currentNumber = queue.Dequeue();

                if (currentNumber % 2 == 0)
                {
                    evenNumbers.Enqueue(currentNumber);
                }
            }

            StringBuilder sb = new StringBuilder();

            while (evenNumbers.Any())
            {
                sb.Append(evenNumbers.Dequeue());
                if (evenNumbers.Any())
                {
                    sb.Append(", ");
                }
            }

            Console.WriteLine(sb);
        }
    }
}
