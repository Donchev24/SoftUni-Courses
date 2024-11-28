namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] reversedInput = input.Reverse().ToArray();

            Stack<string> stack = new Stack<string>(reversedInput);

            int sum = int.Parse(stack.Pop());

            char currentOperation = '+';

            while (stack.Any())
            {
                if (stack.Peek() == "+" || stack.Peek() == "-")
                {
                    currentOperation = char.Parse(stack.Pop());
                }
                else if (stack.Peek() != "+" && stack.Peek() != "-")
                {
                    if (currentOperation == '+')
                    {
                        sum += int.Parse(stack.Pop());
                    }
                    else 
                    {
                        sum -= int.Parse(stack.Pop());
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
