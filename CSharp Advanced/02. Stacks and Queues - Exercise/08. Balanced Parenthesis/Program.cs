namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] expression = input.ToCharArray();

            Stack<char> stack = new();

            for (int i = 0; i < expression.Length; i++)
            {
                if    (expression[i] == '('
                    || expression[i] == '['
                    || expression[i] == '{')
                {
                    stack.Push(expression[i]);
                }
                
                else if (expression[i] == ')'
                   || expression[i] == ']'
                   || expression[i] == '}')
                 {
                    if (stack.Any())
                    {
                        if (stack.Peek() == '(' && expression[i] == ')')
                        {
                            stack.Pop();
                        }
                        else if (stack.Peek() == '[' && expression[i] == ']')
                        {
                            stack.Pop();
                        }
                        else if (stack.Peek() == '{' && expression[i] == '}')
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        stack.Push(expression[i]);
                    }             
                 }
            }

            if (!stack.Any())
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
