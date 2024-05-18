namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Queue<int> queue = new Queue<int>(
                Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            List<int> result = new List<int>();
            int queueLength = queue.Count;

            for (int i = 0; i < queueLength; i++)
            {
                if (queue.Peek() % 2 == 0)
                {
                    result.Add(queue.Dequeue());
                }
                else
                {
                    queue.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", result));

        }
    }
}
