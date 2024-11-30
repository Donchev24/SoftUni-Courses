namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int toPush = tokens[0];
            int toPop = tokens[1];
            int toFind = tokens[2];

            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            if (input.Length >= toPush)
            {
                for (int i = 0; i < toPush; i++)
                {
                    queue.Enqueue(input[i]);
                }
            }

            if (toPop <= queue.Count)
            {
                for (int i = 0; i < toPop; i++)
                {
                    queue.Dequeue();
                }
            }

            if (queue.Contains(toFind))
            {
                Console.WriteLine("true");
            }
            else if (!queue.Any())
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine($"{queue.Min()}");
            }
        }
    }
}
