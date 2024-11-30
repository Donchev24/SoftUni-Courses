namespace _01._Basic_Stack_Operations
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

            Stack<int> stack = new Stack<int>();

            if (input.Length >= toPush)
            {
                for (int i = 0; i < toPush; i++)
                {
                    stack.Push(input[i]);
                }
            }

            if (toPop <= stack.Count)
            {
                for(int i = 0;i < toPop; i++)
                {
                    stack.Pop();
                }
            }

            if (stack.Contains(toFind))
            {
                Console.WriteLine("true");
            }
            else if (!stack.Any())
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine($"{stack.Min()}");
            }
        }
    }
}
