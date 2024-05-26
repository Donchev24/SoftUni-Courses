using System.IO.Pipes;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new(input);
            string command = string.Empty;


            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] inputArgs = command.ToLower().Split();


                if (inputArgs[0] == "add")
                {
                    int firstNumber = int.Parse(inputArgs[1]);
                    int secondNumber = int.Parse(inputArgs[2]);

                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }

                else if (inputArgs[0] == "remove")
                {
                    int removeCount = int.Parse(inputArgs[1]);

                    if (removeCount <= stack.Count)
                    {
                        for (int i = 0; i < removeCount; i++)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
            }

            if (stack.Any())
            {
                Console.WriteLine($"Sum: {stack.Sum()}");
            }
            else
            {
                Console.WriteLine($"Sum: 0");


            }
    }
}
