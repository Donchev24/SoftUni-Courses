namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // 2 + 5 + 10 - 2 - 1

            Stack<string> stack = new (
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                );

            int length = stack.Count;

           


            int sum = 0;
            string currentAction = string.Empty;

            for (int i = 0; i < length; i++)
            {

                if (i % 2 == 0)
                {
                    if (i > 0)
                    {
                        if (currentAction == "+")
                        {
                            sum += int.Parse(stack.Pop());
                        }
                        else
                        {
                            sum -= int.Parse(stack.Pop());
                        }
                    }
                    else
                    {
                        sum = int.Parse(stack.Pop());
                    }
                }
                else
                {
                    currentAction = stack.Pop();
                }


            }

            Console.WriteLine(sum);

        }
    }
}
