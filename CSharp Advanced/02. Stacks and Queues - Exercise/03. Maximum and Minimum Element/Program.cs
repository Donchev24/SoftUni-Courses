namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());

            Stack<uint> stack = new Stack<uint>();

            for (int i = 0; i < n; i++)
            {
                uint[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(uint.Parse).ToArray();

                uint command = input[0];

                if (command == 1)
                {
                    stack.Push(input[1]);
                }
                else if (command == 2 && stack.Any())
                {
                    stack.Pop();
                }
                else if (command == 3 && stack.Any())
                {
                    Console.WriteLine(stack.Max());
                }
                else if (command == 4 && stack.Any())
                {
                    Console.WriteLine(stack.Min());
                }
            }

            if (stack.Any())
            {
                Console.WriteLine(string.Join(", ", stack));
            }
        }
    }
}
